using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web.Resource;
using AzureDesignStudio.SharedModels.Protos;
using AzureDesignStudio.Server.Models;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Azure.Security.KeyVault.Keys.Cryptography;
using Azure.Security.KeyVault.Keys;
using Azure.Identity;
using System.Text;
using Google.Protobuf.WellKnownTypes;

namespace AzureDesignStudio.Server.Services
{
    [Authorize]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAdB2C:Scopes")]
    public class DeployService : Deploy.DeployBase
    {
        private readonly DesignDbContext _designContext;
        private readonly ILogger<DesignService> _logger;
        private readonly CryptographyClient _cryptoClient;
        public DeployService(DesignDbContext context, ILogger<DesignService> logger, IConfiguration configuration)
        {
            _designContext = context;
            _designContext.Database.EnsureCreated();

            _logger = logger;

            var chainedTokenCred = new ChainedTokenCredential(
                    new ManagedIdentityCredential(configuration["MIClientId"]),
                    new AzureCliCredential());
            var keyClient = new KeyClient(new Uri($"https://{configuration["KeyVaultName"]}.vault.azure.net/"),
                chainedTokenCred);
            var key = keyClient.GetKey("adskey1").Value;
            _cryptoClient = new CryptographyClient(key.Id, chainedTokenCred);
        }
        private async Task<string> Encrypt(string plainText)
        {
            byte[] inputAsByteArray = Encoding.UTF8.GetBytes(plainText);
            EncryptResult encryptResult = await _cryptoClient.EncryptAsync(EncryptionAlgorithm.RsaOaep, inputAsByteArray);
            return Convert.ToBase64String(encryptResult.Ciphertext);
        }
        private async Task<string> Decrypt(string encryptedString)
        {
            byte[] inputAsByteArray = Convert.FromBase64String(encryptedString);
            DecryptResult decryptResult = await _cryptoClient.DecryptAsync(EncryptionAlgorithm.RsaOaep, inputAsByteArray);
            return Encoding.Default.GetString(decryptResult.Plaintext);
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
                    ClientSecret = await Encrypt(request.ClientSecret)
                };
                _designContext.AzureSubscriptions.Add(subscription);
            }
            catch(Exception ex)
            {
                _logger.LogWarning("{Exception} occurred.", ex.Message);
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
        public override async Task<LoadSubInfoResponse> LoadSubscriptionInfo(Empty request, ServerCallContext context)
        {
            var response = new LoadSubInfoResponse();

            var userIdClaim = ServiceTools.GetUserId(context);
            if (string.IsNullOrWhiteSpace(userIdClaim))
            {
                _logger.LogWarning("Access denied. userIdClaim is empty.");
                response.StatusCode = StatusCodes.Status401Unauthorized;
                return response;
            }
            var userId = new Guid(userIdClaim);

            var subscriptions = _designContext.AzureSubscriptions.Where(s => s.UserId == userId);

            foreach(var subscription in subscriptions)
            {
                response.SubscriptionInfo.Add(new SubscriptionInfo
                {
                    SubscriptionId = subscription.SubscriptionId.ToString("D"),
                    SubscriptionName = subscription.SubscriptionName,
                    TenantId = subscription.TenantId.ToString("D"),
                    ClientId = subscription.ClientId.ToString("D"),
                    ClientSecret = await Decrypt(subscription.ClientSecret)
                });
            }
            response.StatusCode = StatusCodes.Status200OK;

            return response;
        }
    }
}
