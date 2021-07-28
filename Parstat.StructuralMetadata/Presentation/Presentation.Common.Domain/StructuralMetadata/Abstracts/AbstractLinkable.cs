using Presentation.Common.Domain.StructuralMetadata.Interfaces;

namespace Presentation.Common.Domain.StructuralMetadata.Abstracts
{
    public abstract class AbstractLinkable : AbstractDomain, ILinkable
    {
        public string Link { get; set; }
    }
}
