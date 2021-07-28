using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Infrastructure.Configurations
{
    public class ValueDomainConfiguration : IEntityTypeConfiguration<ValueDomain>
    {
        public void Configure(EntityTypeBuilder<ValueDomain> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}