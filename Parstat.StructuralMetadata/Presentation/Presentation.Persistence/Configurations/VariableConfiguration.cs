using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Infrastructure.Configurations
{
    public class VariableConfiguration : IEntityTypeConfiguration<Variable>
    {
        void IEntityTypeConfiguration<Variable>.Configure(EntityTypeBuilder<Variable> builder)
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
            builder.OwnsOne(v => v.Name);
            builder.OwnsOne(v => v.Description);
            builder.OwnsOne(v => v.VersionRationale);
            builder.OwnsOne(v => v.Definition);
            builder.OwnsOne(v => v.Link);
            
        }
    }
}