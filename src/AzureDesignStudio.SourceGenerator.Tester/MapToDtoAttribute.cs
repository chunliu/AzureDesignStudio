using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDesignStudio.SourceGeneration.Tester
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct
        | AttributeTargets.Property | AttributeTargets.Field)]
    public class MapToDtoAttribute : Attribute
    {
        public string TypeKey = default!;
    }
}
