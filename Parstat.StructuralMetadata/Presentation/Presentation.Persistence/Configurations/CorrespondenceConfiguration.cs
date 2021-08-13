using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Infrastructure.Configurations
{
    public class CorrespondenceConfiguration : IEntityTypeConfiguration<Correspondence>
    {
        public void Configure(EntityTypeBuilder<Correspondence> builder)
        {
             builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            builder.Property(c => c.Relationship)
                .IsRequired();
            builder.Property(c => c.SourceId)
                .IsRequired();
            builder.Property(c => c.TargetId)
                .IsRequired();
            builder.HasIndex(c => new {c.SourceId, c.TargetId})
                .IsUnique();
        }
    }
}