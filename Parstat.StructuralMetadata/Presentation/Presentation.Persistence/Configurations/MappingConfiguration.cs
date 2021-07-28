using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Infrastructure.Configurations
{
    public class MappingConfiguration : IEntityTypeConfiguration<Mapping>
    {
        public void Configure(EntityTypeBuilder<Mapping> builder)
        {
            builder.Property(m => m.CorrespondenceId)
                .IsRequired();
            builder.Property(m => m.SourceId)
                .IsRequired();
            builder.Property(m => m.TargetId)
                .IsRequired();
            builder.HasIndex(m => new {m.SourceId, m.TargetId, m.CorrespondenceId})
                .IsUnique();
        }
    }
}