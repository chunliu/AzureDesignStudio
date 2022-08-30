using AzureDesignStudio.Server.Models;
using AzureDesignStudio.SharedModels.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web.Resource;

namespace AzureDesignStudio.Server.Services
{
    [Authorize]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAdB2C:Scopes")]
    public class DesignService : Design.DesignBase
    {
        private readonly DesignDbContext designContext = null!;
        private readonly ILogger<DesignService> logger;
        public DesignService(DesignDbContext context, ILogger<DesignService> logger)
        {
            designContext = context;
            designContext.Database.EnsureCreated();

            this.logger = logger;
        }

        public override async Task<SaveDesignResponse> Save(SaveDesignRequest request, ServerCallContext context)
        {
            var response = new SaveDesignResponse();
            // Get user id
            var userIdClaim = ServiceTools.GetUserId(context);
            if (string.IsNullOrWhiteSpace(userIdClaim))
            {
                logger.LogWarning("Access denied. userIdClaim is empty.");
                response.StatusCode = StatusCodes.Status401Unauthorized;
                return response;
            }
            var userId = new Guid(userIdClaim);

            // Validate input
            if (!ServiceTools.IsValidName(request.Name))
            {
                logger.LogWarning("{RequestName} is invalid, from user: {UserIdClaim}", request.Name, userIdClaim);
                response.StatusCode = StatusCodes.Status400BadRequest;
                return response;
            }

            // Check quota
            var count = designContext.AdsDesigns.Where(d => d.UserId == userId).Count();
            if (count >= 10)
            {
                logger.LogInformation("Hit quota limit. User: {UserIdClaim}", userIdClaim);
                response.StatusCode = StatusCodes.Status507InsufficientStorage;
                return response;
            }

            var design = designContext.AdsDesigns.FirstOrDefault(d => d.UserId == userId && d.Name == request.Name);
            if (design == null)
            {
                logger.LogInformation("Save new design. Name: {DesignName}", request.Name);
                design = new DesignModel
                {
                    Name = request.Name,
                    UserId = userId,
                    DesignData = request.Data,
                    LastModified = DateTime.Now,
                };
                designContext.AdsDesigns.Add(design);
            }
            else
            {
                logger.LogInformation("Update existing design. Name: {DesignName}", request.Name);
                design.DesignData = request.Data;
                design.LastModified = DateTime.Now;
                designContext.AdsDesigns.Update(design);
            }

            try
            {
                await designContext.SaveChangesAsync();
                response.StatusCode = StatusCodes.Status200OK;
            }
            catch (DbUpdateException dbex)
            {
                logger.LogWarning(dbex, "DbUpdateException occurred.");
                response.StatusCode = StatusCodes.Status400BadRequest;
            }
            catch (Exception ex)
            {
                logger.LogWarning(ex, "Exception occurred.");
                response.StatusCode = StatusCodes.Status500InternalServerError;
            }

            return response;
        }

        public override Task<GetSavedDesignResponse> GetSaved(Empty request, ServerCallContext context)
        {
            var response = new GetSavedDesignResponse();
            // Get user id
            var userIdClaim = ServiceTools.GetUserId(context);
            if (string.IsNullOrEmpty(userIdClaim))
            {
                logger.LogWarning("Access denied. userIdClaim is empty.");
                response.StatusCode = StatusCodes.Status401Unauthorized;
                return Task.FromResult(response);
            }
            var userId = new Guid(userIdClaim);

            var names = designContext.AdsDesigns.Where(d => d.UserId == userId).Select(d => d.Name);
            response.Names.AddRange(names);
            response.StatusCode = StatusCodes.Status200OK;

            return Task.FromResult(response);
        }

        public override async Task<LoadDesignResponse> Load(LoadDesignRequest request, ServerCallContext context)
        {
            var response = new LoadDesignResponse();
            // Get user id
            var userIdClaim = ServiceTools.GetUserId(context);
            if (string.IsNullOrEmpty(userIdClaim))
            {
                logger.LogWarning("Access denied. userIdClaim is empty.");
                response.StatusCode = StatusCodes.Status401Unauthorized;
                return response;
            }

            if (!ServiceTools.IsValidName(request.Name))
            {
                logger.LogWarning("{RequestName} is invalid, from user: {UserIdClaim}", request.Name, userIdClaim);
                response.StatusCode = StatusCodes.Status400BadRequest;
                return response;
            }

            var userId = new Guid(userIdClaim);

            response.Data = (await designContext.AdsDesigns.FirstOrDefaultAsync(d => d.UserId == userId && d.Name == request.Name))?.DesignData;
            if (string.IsNullOrEmpty(response.Data))
            {
                logger.LogWarning("{RequestName} is not found, from user: {UserIdClaim}", request.Name, userIdClaim);
                response.StatusCode = StatusCodes.Status404NotFound;
            }
            else
            {
                response.StatusCode = StatusCodes.Status200OK;
            }

            return response;
        }

        public override async Task<DeleteDesignResponse> Delete(DeleteDesignRequest request, ServerCallContext context)
        {
            var response = new DeleteDesignResponse();
            var userIdClaim = ServiceTools.GetUserId(context);
            if (string.IsNullOrEmpty(userIdClaim))
            {
                logger.LogWarning("Access denied. userIdClaim is empty.");
                response.StatusCode = StatusCodes.Status401Unauthorized;
                return response;
            }

            if (!ServiceTools.IsValidName(request.Name))
            {
                logger.LogWarning("{RequestName} is invalid, from user: {UserIdClaim}", request.Name, userIdClaim);
                response.StatusCode = StatusCodes.Status400BadRequest;
                return response;
            }

            var userId = new Guid(userIdClaim);
            var design = await designContext.AdsDesigns.FirstOrDefaultAsync(d => d.UserId == userId && d.Name == request.Name);
            if (design == null)
            {
                logger.LogWarning("{RequestName} is not found, from user: {UserIdClaim}", request.Name, userIdClaim);
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }

            try
            {
                designContext.AdsDesigns.Remove(design);
                await designContext.SaveChangesAsync();
                response.StatusCode = StatusCodes.Status200OK;
            }
            catch (Exception ex)
            {
                logger.LogWarning(ex, "Exception occurred.");
                response.StatusCode = StatusCodes.Status500InternalServerError;
            }

            return response;
        }
    }
}
