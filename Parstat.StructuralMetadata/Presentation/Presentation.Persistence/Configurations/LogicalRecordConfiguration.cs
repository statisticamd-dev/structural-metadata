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
            builder.Property(lr => lr.Id)
                .ValueGeneratedOnAdd();
            builder.Property(lr => lr.Version)
                .IsRequired(true)
                .HasMaxLength(50);
            builder.Property(lr => lr.LocalId)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasIndex(lr => new { lr.DataStructureId, lr.LocalId, lr.Version })
                .IsUnique();
            builder.Property(lr => lr.VersionDate)
                .IsRequired();
            builder.OwnsOne(lr => lr.Name);
            builder.OwnsOne(lr => lr.Description);
            builder.OwnsOne(lr => lr.VersionRationale);
        }
        
    }
}
