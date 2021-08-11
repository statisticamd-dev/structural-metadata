using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Version)
                .IsRequired(true)
                .HasMaxLength(50);
            builder.Property(c => c.LocalId)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasIndex(c => new {c.LocalId, c.Version})
                .IsUnique();
            builder.Property(c => c.VersionDate)
                .IsRequired();
            builder.OwnsOne(c => c.Name);
            builder.OwnsOne(c => c.Description);
            builder.OwnsOne(c => c.VersionRationale);
            builder.OwnsOne(c => c.Definition);
            builder.OwnsOne(c => c.Link);
        }
    }
}