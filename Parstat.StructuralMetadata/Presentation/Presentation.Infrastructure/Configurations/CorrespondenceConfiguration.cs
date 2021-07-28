using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Infrastructure.Configurations
{
    public class CorrespondenceConfiguration : IEntityTypeConfiguration<Correspondence>
    {
        public void Configure(EntityTypeBuilder<Correspondence> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}