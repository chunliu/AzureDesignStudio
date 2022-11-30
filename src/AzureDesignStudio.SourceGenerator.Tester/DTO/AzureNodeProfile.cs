using Blazor.Diagrams.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDesignStudio.SourceGeneration.Tester.DTO
{
    public partial class AzureNodeProfile
    {
        private void CreateMapForAzureNode<TSource, TTarget>(string typeKey) where TSource : NodeModel where TTarget : AzureNodeDto
        {
            Console.WriteLine($"{nameof(TSource)}, {nameof(TTarget)}");
        }
    }
}
