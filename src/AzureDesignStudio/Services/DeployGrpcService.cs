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

        public async Task<IList<SubscriptionRes>?> GetLinkedSubscriptions()
        {
            IList<SubscriptionRes>? linkedSubscriptions = null;

            var response = await _deployClient.LoadSubscriptionInfoAsync(new Empty());
            if (response.StatusCode == 200)
            {
                linkedSubscriptions = response.SubscriptionData?.ToList();
            }

            return linkedSubscriptions;
        }

        public async Task<int> LinkAzureSubscription(SubscriptionInfo subscriptionInfo)
        {
            var response = await _deployClient.SaveSubscriptionInfoAsync(subscriptionInfo);

            return response.StatusCode;
        }

        public async Task<IList<string>> GetResourceGroups(string subscriptionId)
        {
            var response = await _deployClient.GetResourceGroupsAsync(
                new GetRgsRequest 
                { 
                    SubscriptionId = subscriptionId
                });

            return response.ResourceGroupName.ToList();
        }

        public async Task CreateDeployment(string subscriptionId, string rgName, string armTemplate, string parameters, Action<string, string> updateStatus)
        {
            var request = new DeploymentRequest
            {
                SubscriptionId = subscriptionId,
                ResourceGroupName = rgName,
                ArmTemplate = armTemplate,
                Parameters = parameters,
            };

            using var deploymentResponse = _deployClient.CreateDeployment(request);
            var responseStream = deploymentResponse.ResponseStream;
            while (await responseStream.MoveNext(default))
            {
                var response = responseStream.Current;
                if (response.StatusCode != 200)
                {
                    // Something bad happening
                    updateStatus("error", string.Empty);
                    return;
                }

                updateStatus(response.DeploymentStatus, response.ProvisionState);
            }
        }
    }
}
