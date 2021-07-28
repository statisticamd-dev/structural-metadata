using Microsoft.EntityFrameworkCore;

namespace Presentation.Persistence
{
    public class StructuralMetadataDbContextFactory : DesignTimeDbContextFactoryBase<StructuralMetadataDbContext>
    {
        protected override StructuralMetadataDbContext CreateNewInstance(DbContextOptions<StructuralMetadataDbContext> options)
        {
            return new StructuralMetadataDbContext(options);
        }
    }
}