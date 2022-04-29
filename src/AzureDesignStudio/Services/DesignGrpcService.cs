using AzureDesignStudio.SharedModels.Protos;
using Grpc.Net.ClientFactory;

namespace AzureDesignStudio.Services
{
    public class DesignGrpcService
    {
        private readonly Design.DesignClient _designClient = null!;
        private readonly GrpcClientFactory _clientFactory = null!;

        public DesignGrpcService(GrpcClientFactory grpcClientFactory)
        {
            _clientFactory = grpcClientFactory;
            _designClient = _clientFactory.CreateClient<Design.DesignClient>("DesignClientWithAuth");
        }

        public async Task<int> SaveDesign(string designName, string data)
        {
            var design = new SaveDesignRequest
            {
                Name = designName,
                Data = data
            };

            var response = await _designClient.SaveAsync(design);

            return response.StatusCode;
        }

        public async Task<(int, IList<string>?)> GetAllSavedDesign()
        {
            var response = await _designClient.GetSavedAsync(new GetSavedDesignRequest());

            return (response.StatusCode, response.Names?.ToList());
        }

        public async Task<(int, string?)> LoadDesign(string name)
        {
            var request = new LoadDesignRequest
            {
                Name = name,
            };
            var response = await _designClient.LoadAsync(request);

            return (response.StatusCode, response.Data);
        }

        public async Task<int> DeleteDesign(string name)
        {
            var request = new DeleteDesignRequest { Name = name };
            var response = await _designClient.DeleteAsync(request);
            return response.StatusCode;
        }
    }
}
