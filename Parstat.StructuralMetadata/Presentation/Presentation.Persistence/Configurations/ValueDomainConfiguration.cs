using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Infrastructure.Configurations
{
    public class ValueDomainConfiguration : IEntityTypeConfiguration<ValueDomain>
    {
        public void Configure(EntityTypeBuilder<ValueDomain> builder)
        {
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
            builder.Property(v => v.LevelId)
                .IsRequired(false);
            builder.Property(v => v.NodeSetId)
                .IsRequired(false);
            builder.OwnsOne(v => v.Name);
            builder.OwnsOne(v => v.Description);
            builder.OwnsOne(v => v.VersionRationale);
        }
    }
}