using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Infrastructure.Configurations
{
    public class NodeSetConfiguration : IEntityTypeConfiguration<NodeSet>
    {
        public void Configure(EntityTypeBuilder<NodeSet> builder)
        {
            builder.Property(n => n.Id)
                .ValueGeneratedOnAdd();
            builder.Property(n => n.Version)
                .IsRequired(true)
                .HasMaxLength(50);
            builder.Property(n => n.LocalId)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasIndex(n => new {n.LocalId, n.Version})
                .IsUnique();
            builder.Property(n => n.VersionDate)
                .IsRequired();
            builder.OwnsOne(n => n.Name);
            builder.OwnsOne(n => n.Description);
            builder.OwnsOne(n => n.VersionRationale);
            builder.OwnsOne(n => n.Definition);
            builder.OwnsOne(n => n.Link);
            builder.HasMany(ns => ns.Levels)
                    .WithOne(l => l.NodeSet)
                    .HasForeignKey(l => l.NodeSetId)
                    .OnDelete(DeleteBehavior.Cascade);
             builder.HasMany(ns => ns.Nodes)
                    .WithOne(n => n.NodeSet)
                    .HasForeignKey(n => n.NodeSetId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}