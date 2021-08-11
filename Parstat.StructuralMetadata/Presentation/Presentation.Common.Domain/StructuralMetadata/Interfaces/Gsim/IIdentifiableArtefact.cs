using System;
using System.Collections.Generic;
using System.Text;
using Presentation.Domain;

namespace Presentation.Common.Domain.StructuralMetadata.Interfaces.Gsim
{
    public interface IIdentifiableArtefact : IDomain
    {
        string LocalId { get; set; }
        MultilanguageString Name { get; set; }
        MultilanguageString Description { get; set; }
        string Version { get; set; }
        DateTime VersionDate { get; set; }
        MultilanguageString VersionRationale { get; set; }
    }
}
