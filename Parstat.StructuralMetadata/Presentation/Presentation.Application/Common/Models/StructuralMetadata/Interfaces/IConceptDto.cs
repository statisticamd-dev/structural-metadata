namespace Presentation.Application.Common.Models.StructuralMetadata.Interfaces
{
    public interface IConceptDto : IIdentifiableArtefactDto
    {
         string Definition { get; set; }
         string Link { get; set; }
    }
}