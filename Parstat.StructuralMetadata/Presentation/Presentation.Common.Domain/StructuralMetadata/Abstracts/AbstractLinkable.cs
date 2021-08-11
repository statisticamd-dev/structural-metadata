using Presentation.Common.Domain.StructuralMetadata.Interfaces;
using Presentation.Domain;

namespace Presentation.Common.Domain.StructuralMetadata.Abstracts
{
    public abstract class AbstractLinkable : AbstractDomain, ILinkable
    {
        public MultilanguageString Link { get; set; }
    }
}
