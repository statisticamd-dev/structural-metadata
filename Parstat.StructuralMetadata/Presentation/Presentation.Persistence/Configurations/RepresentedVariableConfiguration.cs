using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Infrastructure.Configurations
{
    public class RepresentedVariableConfiguration : IEntityTypeConfiguration<RepresentedVariable>
    {
        public void Configure(EntityTypeBuilder<RepresentedVariable> builder)
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