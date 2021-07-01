using Presentation.Domain.StructMeta.Interfaces;

namespace Presentation.Domain.StructMeta.Abstracts
{
    public abstract class AbstractLinkable : AbstractDomain, ILinkable
    {
        public string Link { get; set; }
    }
}