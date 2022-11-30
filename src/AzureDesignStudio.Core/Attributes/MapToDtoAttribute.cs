using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDesignStudio.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct
        | AttributeTargets.Property | AttributeTargets.Field)]
    internal class MapToDtoAttribute : Attribute
    {
        public string TypeKey = default!;
    }
}
