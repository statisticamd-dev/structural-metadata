using Presentation.Domain.StructMeta.Interfaces;

namespace Presentation.Domain.StructMeta.Abstracts
{
    public abstract class AbstractDomain : IDomain
    {
        public long Id { get; set; }
    }
}