using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web.Resource;
using AzureDesignStudio.SharedModels.Protos;
using AzureDesignStudio.Server.Models;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Azure.Identity;
using Google.Protobuf.WellKnownTypes;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure;

namespace AzureDesignStudio.Server.Services
{
    [Authorize]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAdB2C:Scopes")]
    public class DeployService : Deploy.DeployBase
    {
        private readonly DesignDbContext _designContext;
        private readonly ILogger<DeployService> _logger;
        private readonly ICryptoService _cryptoService;
        public DeployService(DesignDbContext context, ILogger<DeployService> logger, ICryptoService cryptoService)
        {
            _designContext = context;
            _designContext.Database.EnsureCreated();

            _logger = logger;
            _cryptoService = cryptoService;
        }
        public override async Task<SaveSubInfoResponse> SaveSubscriptionInfo(SubscriptionInfo request, ServerCallContext context)
        {
            var response = new SaveSubInfoResponse();
            // Get user id
            var userIdClaim = ServiceTools.GetUserId(context);
            if (string.IsNullOrWhiteSpace(userIdClaim))
            {
                _logger.LogWarning("Access denied. userIdClaim is empty.");
                response.StatusCode = StatusCodes.Status401Unauthorized;
                return response;
            }
            var userId = new Guid(userIdClaim);

            if(!ServiceTools.IsValidSuscriptionName(request.SubscriptionName))
            {
                _logger.LogWarning("{SubscriptionName} is not valid.", request.SubscriptionName);
                response.StatusCode = StatusCodes.Status400BadRequest;
                return response;
            }

            try
            {
                var subscription = new AzureSubscriptionModel
                {
                    UserId = userId,
                    SubscriptionId = new Guid(request.SubscriptionId),
                    SubscriptionName = request.SubscriptionName,
                    TenantId = new Guid(request.TenantId),
                    ClientId = new Guid(request.ClientId),
                    ClientSecret = await _cryptoService.Encrypt(request.ClientSecret)
                };
                _designContext.AzureSubscriptions.Add(subscription);
            }
            catch(Exception ex)
            {
                _logger.LogWarning(ex, "Exception occurred.");
                response.StatusCode = StatusCodes.Status400BadRequest;
                return response;
            }

            try
            {
                await _designContext.SaveChangesAsync();
                response.StatusCode = StatusCodes.Status200OK;
            }
            catch (DbUpdateException dbex)
            {
                _logger.LogWarning(dbex, "DbUpdateException occurred.");
                response.StatusCode = StatusCodes.Status400BadRequest;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Exception occurred.");
                response.StatusCode = StatusCodes.Status500InternalServerError;
            }

            return response;
        }
        public override Task<LoadSubInfoResponse> LoadSubscriptionInfo(Empty request, ServerCallContext context)
        {
            var response = new LoadSubInfoResponse();

            var userIdClaim = ServiceTools.GetUserId(context);
            if (string.IsNullOrWhiteSpace(userIdClaim))
            {
                _logger.LogWarning("Access denied. userIdClaim is empty.");
                response.StatusCode = StatusCodes.Status401Unauthorized;
                return Task.FromResult(response);
            }
            var userId = new Guid(userIdClaim);

            var subResources = _designContext.AzureSubscriptions.Where(s => s.UserId == userId);
            foreach(var subResource in subResources)
            {
                response.SubscriptionData.Add(new SubscriptionRes
                {
                    SubscriptionId = subResource.SubscriptionId.ToString(),
                    SubscriptionName = subResource.SubscriptionName,
                });
            }
            response.StatusCode = StatusCodes.Status200OK;

            return Task.FromResult(response);
        }
        private async Task<AzureSubscriptionModel?> GetSubscriptionInfo(Guid userId)
        {
            var subModel = _designContext.AzureSubscriptions.Where(s => s.UserId == userId).FirstOrDefault();
            if (subModel == null)
                return null;

            subModel.ClientSecret = await _cryptoService.Decrypt(subModel.ClientSecret);
            return subModel;
        }
        private async Task<SubscriptionResource?> GetSubscriptionResource(Guid userId)
        {
            var subModel = await GetSubscriptionInfo(userId);
            if (subModel == null)
                return null;

            var azCred = new ClientSecretCredential(subModel.TenantId.ToString(), 
                subModel.ClientId.ToString(), subModel.ClientSecret);
            var armClient = new ArmClient(azCred, subModel.SubscriptionId.ToString());
            var subResource = await armClient.GetDefaultSubscriptionAsync();

            return subResource;
        }
        public override async Task<DeploymentResponse> CreateDeployment(DeploymentRequest request, ServerCallContext context)
        {
            var response = new DeploymentResponse();

            var userIdClaim = ServiceTools.GetUserId(context);
            if (string.IsNullOrWhiteSpace(userIdClaim))
            {
                _logger.LogWarning("Access denied. userIdClaim is empty.");
                response.StatusCode = StatusCodes.Status401Unauthorized;
                return response;
            }
            var userId = new Guid(userIdClaim);
            var subResource = await GetSubscriptionResource(userId);
            if (subResource == null)
            {
                _logger.LogWarning("No subscription is found.");
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }

            return response;
        }

        public override async Task<GetRgsResponse> GetResourceGroups(Empty request, ServerCallContext context)
        {
            var response = new GetRgsResponse();

            var userIdClaim = ServiceTools.GetUserId(context);
            if (string.IsNullOrWhiteSpace(userIdClaim))
            {
                _logger.LogWarning("Access denied. userIdClaim is empty.");
                response.StatusCode = StatusCodes.Status401Unauthorized;
                return response;
            }
            var userId = new Guid(userIdClaim);
            var subResource = await GetSubscriptionResource(userId);
            if (subResource == null)
            {
                _logger.LogWarning("No subscription is found.");
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }

            var rgNames = subResource.GetResourceGroups()?.Select(rg => rg.Data.Name);
            response.ResourceGroupName.AddRange(rgNames);
            response.StatusCode = StatusCodes.Status200OK;

            return response;
        }
    }
}
