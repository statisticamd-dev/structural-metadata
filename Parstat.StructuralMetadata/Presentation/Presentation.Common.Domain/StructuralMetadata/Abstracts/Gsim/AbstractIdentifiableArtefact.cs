using Presentation.Common.Domain.StructuralMetadata.Interfaces.Gsim;
using System;

namespace Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim
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
