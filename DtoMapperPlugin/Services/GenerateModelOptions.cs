using Microsoft.Xrm.Sdk.Metadata;
using System.Collections.Generic;

namespace DtoMapperPlugin.Services
{
    internal class GenerateModelOptions
    {
        public string Namespace { get; set; }
        public EntityMetadata Entity { get; set; }
        public IEnumerable<AttributeMetadata> Attributes { get; set; }
        public bool GenerateLabels { get; set; }
    }
}
