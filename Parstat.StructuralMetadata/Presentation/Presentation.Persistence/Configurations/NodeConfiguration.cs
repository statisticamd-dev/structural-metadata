using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Infrastructure.Configurations
{
    public class NodeConfiguration : IEntityTypeConfiguration<Node>
    {
        public void Configure(EntityTypeBuilder<Node> builder)
        {
            builder.Property(n => n.AggregationType)
                .IsRequired();
            builder.Property(n => n.Code)
                .IsRequired();
            builder.HasIndex(n => new {n.Code, n.NodeSetId})
                .IsUnique();
            builder.Property(n => n.LabelId)
                .IsRequired();
        }
    }
}