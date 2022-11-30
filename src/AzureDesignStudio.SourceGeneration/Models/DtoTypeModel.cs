using System.Collections.Generic;

namespace AzureDesignStudio.SourceGeneration.Models
{
    internal class DtoTypeProperty
    {
        public string Identifier { get; set; } = default!;
        public string Type { get; set; } = default!;
    }
    internal class DtoTypeModel
    {
        public string Namespace { get; set; } = default!;
        public string ClassName { get; set; } = default!;
        public IList<string> Usings { get; set; } = default!;
        public IList<DtoTypeProperty> Properties { get; set; } = default!;
    }
}
