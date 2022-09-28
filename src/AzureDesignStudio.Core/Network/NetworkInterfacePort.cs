using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;

namespace AzureDesignStudio.Core.Network
{
    public class NetworkInterfacePort : PortModel
    {
        public NetworkInterfacePort(NodeModel parent, PortAlignment alignment, Point? position = null, Size? size = null)
            : base(parent, alignment, position, size)
        {
            if (parent == null)
            {

            }
            else if (parent.Group is not SubnetModel)
            {

            }
        }

        public override bool CanAttachTo(PortModel port)
        {
            if (!base.CanAttachTo(port))
                return false;

            return true;
        }
    }
}
