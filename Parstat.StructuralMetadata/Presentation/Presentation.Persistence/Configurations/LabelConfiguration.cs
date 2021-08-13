using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Infrastructure.Configurations
{
    public class LabelConfiguration : IEntityTypeConfiguration<Label>
    {
        public void Configure(EntityTypeBuilder<Label> builder)
        {
             builder.Property(l => l.Id)
                .ValueGeneratedOnAdd();
            builder.OwnsOne(l => l.Value);
        }
    }
}