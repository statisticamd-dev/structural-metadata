using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Infrastructure.Configurations
{
    public class RepresentedVariableConfiguration : IEntityTypeConfiguration<RepresentedVariable>
    {
        public void Configure(EntityTypeBuilder<RepresentedVariable> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}