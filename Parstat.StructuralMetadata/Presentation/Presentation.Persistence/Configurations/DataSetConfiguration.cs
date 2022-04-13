using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;

namespace Presentation.Persistence.Configurations
{
    public class DataSetConfiguration : IEntityTypeConfiguration<DataSet>
    {
         public void Configure(EntityTypeBuilder<DataSet> builder)
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
            builder.Property(ds => ds.VersionDate)
                .IsRequired();
            builder.Property(ds => ds.StatisticalProgramId)
                .IsRequired();
            builder.OwnsOne(ds => ds.Name);
            builder.OwnsOne(ds => ds.Description);
            builder.OwnsOne(ds => ds.VersionRationale);
            
        }
    }
}
