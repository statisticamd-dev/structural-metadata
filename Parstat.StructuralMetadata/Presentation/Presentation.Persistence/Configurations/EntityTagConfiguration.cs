using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presentation.Domain.StructuralMetadata.Entities.Tags;

namespace Presentation.Persistence.Configurations
{
    public class EntityTagConfiguration : IEntityTypeConfiguration<EntityTag>
    {
        public void Configure(EntityTypeBuilder<EntityTag> builder)
        {
            builder.Property(et => et.Id)
                .ValueGeneratedOnAdd();
            builder.HasIndex(et => new {et.EntityId, et.EntityType, et.TagId})
                .IsUnique();
        }
    }
}
