using Microsoft.EntityFrameworkCore;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Infrastructure.Configurations
{
    public class MeasurementTypeConfiguration : IEntityTypeConfiguration<MeasurementType>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MeasurementType> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}