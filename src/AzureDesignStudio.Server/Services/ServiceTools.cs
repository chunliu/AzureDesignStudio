using Grpc.Core;
using System.Text.RegularExpressions;

namespace AzureDesignStudio.Server.Services
{
    public static class ServiceTools
    {
        internal static string? GetUserId(ServerCallContext context)
        {
            var user = context.GetHttpContext().User;
            return user.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value;
        }

        internal static bool IsValidName(string name)
        {
            Regex regex = new(@"^[a-zA-Z0-9\s]+$"); // Alphanumeric characters and whitespace
            if (string.IsNullOrWhiteSpace(name) || name.Length > 200 || !regex.IsMatch(name))
                return false;

            return true;
        }

        internal static bool IsValidSubscriptionName(string subscriptionName)
        {
            Regex regex = new(@"^[^<>;|]+$"); // Azure subscription name cannot have these characters: < > ; |
            if (string.IsNullOrWhiteSpace(subscriptionName) || subscriptionName.Length > 64 
                || !regex.IsMatch(subscriptionName))
                return false;

            return true;
        }
    }
}
