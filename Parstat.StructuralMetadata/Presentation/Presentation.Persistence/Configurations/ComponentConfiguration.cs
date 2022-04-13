using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;

namespace Presentation.Persistence.Configurations
{
    public class ComponentConfiguration : IEntityTypeConfiguration<Component>
    {
         public void Configure(EntityTypeBuilder<Component> builder)
        {
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            builder.Property(c => c.Version)
                .IsRequired(true)
                .HasMaxLength(50);
            builder.Property(c => c.LocalId)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasIndex(c => new { c.LocalId, c.Version })
                .IsUnique();
            builder.Property(c => c.VersionDate)
                .IsRequired();
            builder.Property(c => c.RepresentedVariableId)
                .IsRequired();
            builder.OwnsOne(c => c.Name);
            builder.OwnsOne(c => c.Description);
            builder.OwnsOne(c => c.VersionRationale);
        }
        
    }
}
