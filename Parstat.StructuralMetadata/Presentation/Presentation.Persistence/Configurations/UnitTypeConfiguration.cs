using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Infrastructure.Configurations
{
    public class UnitTypeConfiguration :  IEntityTypeConfiguration<UnitType>
    {
        public void Configure(EntityTypeBuilder<UnitType> builder)
        {
            builder.Property(u => u.Version)
                .IsRequired(true)
                .HasMaxLength(50);
            builder.Property(u => u.LocalId)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasIndex(u => new {u.LocalId, u.Version})
                .IsUnique();
            builder.Property(u => u.VersionDate)
                .IsRequired();
            builder.OwnsOne(u => u.Name);
            builder.OwnsOne(u => u.Description);
            builder.OwnsOne(u => u.VersionRationale);
            builder.OwnsOne(u => u.Definition);
            builder.OwnsOne(u => u.Link);
            
        }
    }
}