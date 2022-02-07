using AzureDesignStudio.Core;
using AzureDesignStudio.Core.Components;
using Blazor.Diagrams.Core;
using System.Net.Http.Json;

namespace AzureDesignStudio.Models
{
    public class AdsContext
    {
        private readonly IHttpClientFactory clientFactory = null!;
        public AdsContext(IHttpClientFactory factory)
        {
            clientFactory = factory;
        }

        public async Task InitializeAsync()
        {
            if (AllStencils == null)
            {
                var httpClient = clientFactory.CreateClient("AzureDesignStudio.ResourceAccess");
                AllStencils = (await httpClient.GetFromJsonAsync<IReadOnlyList<StencilModel>>("ads-stencils.json"))!
                    .OrderBy(s => s.Label).ToList();
            }
        }
        public Diagram Diagram { get; set; } = new Diagram(
              new DiagramOptions
              {
                  DeleteKey = "NotAllowed", // What key deletes the selected nodes/links
                  DefaultNodeComponent = typeof(AzureNodeComponent), // Default component for nodes
                  AllowMultiSelection = true, // Whether to allow multi selection using CTRL
                  Groups = new()
                  {
                      Enabled = false,
                  },
                  Links = new DiagramLinkOptions
                  {
                      DefaultRouter = Routers.Orthogonal,
                      DefaultPathGenerator = PathGenerators.Straight,
                      Factory = DataModelFactory.LinkModelFactory,
                  },
                  Zoom = new DiagramZoomOptions
                  {
                      Minimum = 0.5, // Minimum zoom value
                      Inverse = false, // Whether to inverse the direction of the zoom when using the wheel
                                       // Other
                  }
              }
          );
        public string DraggedStencilKey { get; set; } = string.Empty;
        public string CurrentDesignName { get; set; } = null!;

        public IReadOnlyList<StencilModel> AllStencils = null!;
    }
}
