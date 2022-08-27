using AzureDesignStudio.SharedModels.Protos;
using Grpc.Net.ClientFactory;
using Google.Protobuf.WellKnownTypes;

namespace AzureDesignStudio.Services
{
    public class DeployGrpcService
    {
        private readonly Deploy.DeployClient _deployClient = null!;
        private readonly GrpcClientFactory _clientFactory = null!;
        public DeployGrpcService(GrpcClientFactory grpcClientFactory)
        {
            _clientFactory = grpcClientFactory;
            _deployClient = _clientFactory.CreateClient<Deploy.DeployClient>("DeployClientWithAuth");
        }

        public async Task<IList<string>?> GetLinkedSubscriptions()
        {
            IList<string>? linkedSubscriptions = null;

            var response = await _deployClient.LoadSubscriptionInfoAsync(new Empty());
            if (response.StatusCode == 200)
            {
                linkedSubscriptions = response.SubscriptionNames?.ToList();
            }

            return linkedSubscriptions;
        }

        public async Task<int> LinkAzureSubscription(SubscriptionInfo subscriptionInfo)
        {
            var response = await _deployClient.SaveSubscriptionInfoAsync(subscriptionInfo);

            return response.StatusCode;
        }
    }
}
