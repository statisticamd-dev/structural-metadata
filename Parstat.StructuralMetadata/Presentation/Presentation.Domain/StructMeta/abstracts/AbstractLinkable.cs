using Presentation.Domain.StructMeta.interfaces;

namespace Presentation.Domain.StructMeta.abstracts
{
    public abstract class AbstractLinkable : AbstractDomain, ILinkable
    {
        public string Link { get; set; }
    }
}