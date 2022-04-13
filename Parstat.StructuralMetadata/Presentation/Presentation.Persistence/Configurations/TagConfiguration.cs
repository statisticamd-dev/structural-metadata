using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presentation.Domain.StructuralMetadata.Entities.Tags;

namespace Presentation.Persistence.Configurations
{
    public class TagConfiguration :  IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();
            builder.OwnsOne(t => t.Name); 
        }
    }
}
