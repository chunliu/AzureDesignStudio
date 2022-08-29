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
using Azure.ResourceManager.Resources.Models;
using Azure.Deployments.Core.Definitions;

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
        private async Task<AzureSubscriptionModel?> GetSubscriptionInfo(Guid userId, Guid subscriptionId)
        {
            var subModel = _designContext.AzureSubscriptions.Where(s => s.UserId == userId && s.SubscriptionId == subscriptionId)
                .FirstOrDefault();
            if (subModel == null)
                return null;

            subModel.ClientSecret = await _cryptoService.Decrypt(subModel.ClientSecret);
            return subModel;
        }
        private async Task<SubscriptionResource?> GetSubscriptionResource(Guid userId, Guid subscriptionId)
        {
            var subModel = await GetSubscriptionInfo(userId, subscriptionId);
            if (subModel == null)
                return null;

            var azCred = new ClientSecretCredential(subModel.TenantId.ToString(), 
                subModel.ClientId.ToString(), subModel.ClientSecret);
            var armClient = new ArmClient(azCred, subModel.SubscriptionId.ToString());
            var subResource = await armClient.GetDefaultSubscriptionAsync();

            return subResource;
        }
        public override async Task CreateDeployment(DeploymentRequest request, IServerStreamWriter<DeploymentResponse> responseStream, ServerCallContext context)
        {
            var response = new DeploymentResponse();

            if (string.IsNullOrWhiteSpace(request.ArmTemplate))
            {
                _logger.LogWarning("ArmTemplate is empty");
                response.StatusCode = StatusCodes.Status400BadRequest;
                await responseStream.WriteAsync(response);
                return;
            }

            var userIdClaim = ServiceTools.GetUserId(context);
            if (string.IsNullOrWhiteSpace(userIdClaim))
            {
                _logger.LogWarning("Access denied. userIdClaim is empty.");
                response.StatusCode = StatusCodes.Status401Unauthorized;
                await responseStream.WriteAsync(response);
                return;
            }
            var userId = new Guid(userIdClaim);

            Guid subscriptionId;
            try
            {
                subscriptionId = new Guid(request.SubscriptionId);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Exception occurred.");
                response.StatusCode = StatusCodes.Status400BadRequest;
                await responseStream.WriteAsync(response);
                return;
            }

            var subResource = await GetSubscriptionResource(userId, subscriptionId);
            if (subResource == null)
            {
                _logger.LogWarning("No subscription is found.");
                response.StatusCode = StatusCodes.Status404NotFound;
                await responseStream.WriteAsync(response);
                return;
            }

            var rg = (await subResource.GetResourceGroupAsync(request.ResourceGroupName))?.Value;
            if (rg == null)
            {
                _logger.LogWarning("{ResourceGroup} cannot be found.", request.ResourceGroupName);
                response.StatusCode = StatusCodes.Status404NotFound;
                await responseStream.WriteAsync(response);
                return;
            }
            // Deploy the template
            ArmDeploymentCollection armDeployments = rg.GetArmDeployments();
            string deploymentName = "ads-deployment";
            var input = new ArmDeploymentContent(new ArmDeploymentProperties(ArmDeploymentMode.Incremental)
            {
                Template = BinaryData.FromString(request.ArmTemplate),
                Parameters = BinaryData.FromString(request.Parameters),
            });
            try
            {
                ArmOperation<ArmDeploymentResource> lro = await armDeployments.CreateOrUpdateAsync(WaitUntil.Started, deploymentName, input);

                while(!lro.HasCompleted)
                {
                    response.StatusCode = StatusCodes.Status200OK;
                    response.DeploymentStatus = "processing";
                    await responseStream.WriteAsync(response);
                    await lro.UpdateStatusAsync();
                    await Task.Delay(2000);
                }

                response.StatusCode = StatusCodes.Status200OK;
                response.DeploymentStatus = "completed";
                response.ProvisionState = "succeeded";
                await responseStream.WriteAsync(response);
            }
            catch (RequestFailedException ex)
            {
                _logger.LogWarning(ex, "Request Failed Exception");
                response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                response.DeploymentStatus = "failed";
                await responseStream.WriteAsync(response);
            }
        }

        public override async Task<GetRgsResponse> GetResourceGroups(GetRgsRequest request, ServerCallContext context)
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
            Guid subscriptionId;
            try
            {
                subscriptionId = new Guid(request.SubscriptionId);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Exception occurred.");
                response.StatusCode = StatusCodes.Status400BadRequest;
                return response;
            }

            var subResource = await GetSubscriptionResource(userId, subscriptionId);
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
