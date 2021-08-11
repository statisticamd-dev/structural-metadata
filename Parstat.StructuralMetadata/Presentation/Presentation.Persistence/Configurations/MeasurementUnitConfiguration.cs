using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Infrastructure.Configurations
{
    public class MeasurementUnitConfiguration : IEntityTypeConfiguration<MeasurementUnit>
    {
        public void Configure(EntityTypeBuilder<MeasurementUnit> builder)
        {
            builder.Property(m => m.Version)
                .IsRequired(true)
                .HasMaxLength(50);
            builder.Property(m => m.LocalId)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasIndex(m => new {m.LocalId, m.Version})
                .IsUnique();
            builder.Property(m => m.VersionDate)
                .IsRequired();
            builder.OwnsOne(m => m.Name);
            builder.OwnsOne(m => m.Description);
            builder.OwnsOne(m => m.VersionRationale);
        }
    }
}