using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Presentation.Application.Common.Interfaces;
using Presentation.Common.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Persistence
{
    public class StructuralMetadataDbContext : DbContext, IStructuralMetadataDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public StructuralMetadataDbContext(DbContextOptions<StructuralMetadataDbContext> options)
            : base(options)
        {
        }

        public StructuralMetadataDbContext(
            DbContextOptions<StructuralMetadataDbContext> options, 
            ICurrentUserService currentUserService,
            IDateTime dateTime)
            : base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Correspondence> Correspondences { get; set; }
        public DbSet<Concept> Concepts { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Mapping> Mappings { get; set; }
        public DbSet<MeasurementType> MeasurementTypes { get; set; }
        public DbSet<MeasurementUnit> MeasurementUnits { get; set; }
        public DbSet<Node> Nodes { get; set; }
        public DbSet<NodeSet> NodeSets { get; set; }
        public DbSet<RepresentedVariable> RepresentedVariables { get; set; }
        public DbSet<UnitType> UnitTypes { get; set; }
        public DbSet<ValueDomain> ValueDomains { get; set; }
        public DbSet<Variable> Variables { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public EntityEntry Entry(AuditableEntity entity)
        {
            return base.Entry(entity);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("iais_structural");
            modelBuilder
                .Entity<ValueDomain>()
                .Property(v => v.Type)
                .HasConversion<string>();
            modelBuilder
                .Entity<ValueDomain>()
                .Property(v => v.DataType)
                .HasConversion<string>();
            modelBuilder
                .Entity<ValueDomain>()
                .Property(v => v.Scope)
                .HasConversion<string>();
            modelBuilder
                .Entity<NodeSet>()
                .Property(n => n.NodeSetType)
                .HasConversion<string>();
            modelBuilder
                .Entity<Node>()
                .Property(n => n.AggregationType)
                .HasConversion<string>();
            modelBuilder
                .Entity<Correspondence>() 
                .Property(c => c.Relationship)
                .HasConversion<string>();
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(StructuralMetadataDbContext).Assembly);
        }

       
    }
}