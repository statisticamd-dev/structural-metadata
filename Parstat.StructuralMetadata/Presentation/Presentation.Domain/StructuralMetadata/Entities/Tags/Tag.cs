using System;
using Presentation.Common.Domain.StructuralMetadata.Abstracts;
using Presentation.Common.Domain.StructuralMetadata.Enums;

namespace Presentation.Domain.StructuralMetadata.Entities.Tags
{
    public class Tag : AbstractDomain
    {
        public MultilanguageString Name { get; set; }
        public TagType Type { get; set; }
        public long ParentId { get; set; }
        public Tag Parent { get; set; }
    }
}
