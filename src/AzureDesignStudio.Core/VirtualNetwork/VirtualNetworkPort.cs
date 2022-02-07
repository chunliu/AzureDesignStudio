using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;

namespace AzureDesignStudio.Core.VirtualNetwork
{
    public class VirtualNetworkPort : PortModel
    {
        public VirtualNetworkPort(NodeModel parent, PortAlignment alignment, Point? position = null, Size? size = null) 
            : base(parent, alignment, position, size)
        {
        }

        public override bool CanAttachTo(PortModel port)
        {
            if (!base.CanAttachTo(port) || port is not VirtualNetworkPort)
                return false;

            foreach(var sibling in Parent.Ports)
            {
                // Only one vnet-peering can be established.
                if (sibling.Links.Any(l => l.SourcePort?.Parent.Id == port.Parent.Id 
                    || l.TargetPort?.Parent.Id == port.Parent.Id))
                    return false;
            }

            return true;
        }
    }
}
