using Presentation.Common.Domain.StructuralMetadata.Interfaces.Gsim;
using Presentation.Domain;
using System;

namespace Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim
{
    public abstract class AbstractIdentifiableArtefact : AbstractDomain, IIdentifiableArtefact
    {
        public string LocalId { get; set; }
        public MultilanguageString Name { get; set; }
        public MultilanguageString Description { get; set; }
        public string Version { get; set; }
        public DateTime VersionDate { get; set; }
        public MultilanguageString VersionRationale { get; set; }
    }
}
