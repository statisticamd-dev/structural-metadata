using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Infrastructure.Configurations
{
    public class LevelConfiguration : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.Property(l => l.Id)
               .ValueGeneratedOnAdd();
            builder.Property(l => l.Version)
                .IsRequired(true)
                .HasMaxLength(50);
            builder.Property(l => l.LocalId)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasIndex(l => new { l.LocalId, l.Version })
                .IsUnique();
            builder.Property(l => l.VersionDate)
                .IsRequired();
            builder.OwnsOne(l => l.Name);
            builder.OwnsOne(l => l.Description);
            builder.OwnsOne(l => l.VersionRationale);
        }
    }
}