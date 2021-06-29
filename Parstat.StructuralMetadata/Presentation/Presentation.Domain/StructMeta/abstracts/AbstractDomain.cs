using Presentation.Domain.StructMeta.interfaces;
namespace Presentation.Domain.StructMeta.abstracts
{
    public abstract class AbstractDomain : IDomain
    {
        public long Id { get; set; }
    }
}