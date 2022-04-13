using System;
using Presentation.Common.Domain.StructuralMetadata.Abstracts;
using Presentation.Common.Domain.StructuralMetadata.Enums;

namespace Presentation.Domain.StructuralMetadata.Entities.Tags
{
    public class EntityTag : AbstractDomain
    {
        public long EntityId { get; set; }
        public EntityType EntityType { get; set; }
        public long TagId { get; set; }
        public Tag Tag { get; set; }

    }
}
