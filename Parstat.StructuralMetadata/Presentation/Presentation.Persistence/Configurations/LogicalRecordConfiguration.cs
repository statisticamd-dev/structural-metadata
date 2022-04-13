using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;

namespace Presentation.Persistence.Configurations
{
    public class LogicalRecordConfiguration : IEntityTypeConfiguration<LogicalRecord>
    {
         public void Configure(EntityTypeBuilder<LogicalRecord> builder)
        {
            builder.Property(ds => ds.Id)
                .ValueGeneratedOnAdd();
            builder.Property(ds => ds.Version)
                .IsRequired(true)
                .HasMaxLength(50);
            builder.Property(ds => ds.LocalId)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasIndex(ds => new { ds.LocalId, ds.Version })
                .IsUnique();
            builder.Property(l => l.VersionDate)
                .IsRequired();
            builder.OwnsOne(ds => ds.Name);
            builder.OwnsOne(ds => ds.Description);
            builder.OwnsOne(ds => ds.VersionRationale);
        }
        
    }
}
