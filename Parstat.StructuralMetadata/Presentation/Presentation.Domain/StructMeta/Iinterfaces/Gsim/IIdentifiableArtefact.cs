using System;

namespace Presentation.Domain.StructMeta.Interfaces.Gsim
{
    public interface IIdentifiableArtefact : IDomain
    {
        string LocalId { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Version { get; set; }        
        DateTime VersionDate { get; set; }
        string VersionRationale { get; set; }
    }
}