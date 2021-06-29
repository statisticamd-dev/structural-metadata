using Presentation.Domain.StructMeta.interfaces.gsim;
namespace Presentation.Domain.StructMeta.abstracts.gsim
{
    public class AbstractIdentifiableArtefact : AbstractDomain, IIdentifiableArtefact
    {
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        //TODO add property Date: VersionDate here
        //public Date VersionDate { get; set; }
        public string VersionRationale { get; set; }
    }
}