using Presentation.Common.Domain.StructuralMetadata.Interfaces;

namespace Presentation.Common.Domain.StructuralMetadata.Abstracts
{
    public abstract class AbstractDomain : AuditableEntity, IDomain
    {
        public long Id { get; set; }
    }
}
