using System;

namespace Presentation.Application.Common.Models.StructuralMetadata.Interfaces
{
    public interface IIdentifiableArtefactDto : IBaseDto
    {
        string LocalId { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Version { get; set; }
        DateTime VersionDate { get; set; }
        string VersionRationale { get; set; }
    }
}