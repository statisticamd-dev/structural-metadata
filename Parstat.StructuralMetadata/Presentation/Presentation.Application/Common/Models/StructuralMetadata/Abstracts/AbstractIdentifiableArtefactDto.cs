using System;
using Presentation.Application.Common.Models.StructuralMetadata.Interfaces;

namespace Presentation.Application.Common.Models.StructuralMetadata.Abstracts
{
    public abstract class AbstractIdentifiableArtefactDto : AbstractBaseDto, IIdentifiableArtefactDto
    {
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public DateTime VersionDate { get; set; }
        public string VersionRationale { get; set; }
    }
}