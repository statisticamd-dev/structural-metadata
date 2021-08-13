using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Persistence.Configurations
{
    public class RepresentedVariableValueDomainConfiguration : IEntityTypeConfiguration<RepresentedVariableValueDomain>
    {
        public void Configure(EntityTypeBuilder<RepresentedVariableValueDomain> builder)
        {
            builder.Property(r => r.Id)
                .ValueGeneratedOnAdd();
            builder.Property(v => v.RepresentedVariableId)
                .IsRequired();
            builder.Property(v => v.ValueDomainId)
                .IsRequired();
            builder.Property(v => v.Scope)
                .IsRequired();
            builder.HasIndex(v => new {v.RepresentedVariableId, v.Scope})
                .IsUnique();
        }
    }
}