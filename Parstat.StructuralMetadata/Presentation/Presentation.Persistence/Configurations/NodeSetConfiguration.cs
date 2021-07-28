using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Infrastructure.Configurations
{
    public class NodeSetConfiguration : IEntityTypeConfiguration<NodeSet>
    {
        public void Configure(EntityTypeBuilder<NodeSet> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}