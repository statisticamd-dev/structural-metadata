using Microsoft.EntityFrameworkCore;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Infrastructure.Configurations
{
    public class MeasurementTypeConfiguration : IEntityTypeConfiguration<MeasurementType>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MeasurementType> builder)
        {
            builder.Property(v => v.Name)
                .IsRequired(true)
                .HasMaxLength(100);
            builder.Property(v => v.Description)
                .IsRequired(false)
                .HasMaxLength(255);
            builder.Property(v => v.Version)
                .IsRequired(true)
                .HasMaxLength(50);
            builder.Property(v => v.LocalId)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasIndex(v => new {v.LocalId, v.Version})
                .IsUnique();
            builder.Property(v => v.VersionDate)
                .IsRequired();
            builder.Property(v => v.VersionRationale)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}