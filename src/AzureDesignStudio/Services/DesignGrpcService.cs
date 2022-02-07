using AzureDesignStudio.SharedModels.Protos;

namespace AzureDesignStudio.Services
{
    public class DesignGrpcService
    {
        private readonly Design.DesignClient designClient = null!;

        public DesignGrpcService(Design.DesignClient client) => designClient = client;

        public async Task<int> SaveDesign(string designName, string data)
        {
            var design = new SaveDesignRequest
            {
                Name = designName,
                Data = data
            };

            var response = await designClient.SaveAsync(design);

            return response.StatusCode;
        }

        public async Task<(int, IList<string>?)> GetAllSavedDesign()
        {
            var response = await designClient.GetSavedAsync(new GetSavedDesignRequest());

            return (response.StatusCode, response.Names?.ToList());
        }

        public async Task<(int, string?)> LoadDesign(string name)
        {
            var request = new LoadDesignRequest
            {
                Name = name,
            };
            var response = await designClient.LoadAsync(request);

            return (response.StatusCode, response.Data);
        }

        public async Task<int> DeleteDesign(string name)
        {
            var request = new DeleteDesignRequest { Name = name };
            var response = await designClient.DeleteAsync(request);
            return response.StatusCode;
        }
    }
}
