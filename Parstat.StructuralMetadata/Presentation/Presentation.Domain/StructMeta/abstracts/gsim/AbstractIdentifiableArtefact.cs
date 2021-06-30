using System;
using Presentation.Domain.StructMeta.interfaces.gsim;

namespace Presentation.Domain.StructMeta.abstracts.gsim
{
    public abstract class AbstractIdentifiableArtefact : AbstractDomain, IIdentifiableArtefact
    {
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public DateTime VersionDate { get; set; }
        public string VersionRationale { get; set; }
    }
}