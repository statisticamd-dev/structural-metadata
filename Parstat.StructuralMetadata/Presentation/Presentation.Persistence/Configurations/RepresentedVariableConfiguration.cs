using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Infrastructure.Configurations
{
    public class RepresentedVariableConfiguration : IEntityTypeConfiguration<RepresentedVariable>
    {
        public void Configure(EntityTypeBuilder<RepresentedVariable> builder)
        {
            builder.Property(r => r.Id)
                .ValueGeneratedOnAdd();
            builder.Property(r => r.Version)
                .IsRequired(true)
                .HasMaxLength(50);
            builder.Property(r => r.LocalId)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasIndex(r => new {r.LocalId, r.Version})
                .IsUnique();
            builder.Property(r => r.VersionDate)
                .IsRequired();
            builder.HasOne(r => r.SentinelValueDomain)
                .WithMany(v => v.SentinelRepresentations)
                .HasForeignKey(r => r.SentinelValueDomainId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(r => r.SubstantiveValueDomain)
                .WithMany(v => v.SubstantiveRepresentations)
                .HasForeignKey(r => r.SubstantiveValueDomainId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.OwnsOne(r => r.Name);
            builder.OwnsOne(r => r.Description);
            builder.OwnsOne(r => r.VersionRationale);
            builder.OwnsOne(r => r.Definition);
            builder.OwnsOne(r => r.Link);
                /*
            builder.HasOne(r => r.SentinelValueDomain)
                .WithMany(s => s.RepresentedVariables)
                .HasForeignKey(r => r.SentinelValueDomainId);
            builder.HasOne(r => r.SubstantiveValueDomain)
                    .WithMany(s => s.RepresentedVariables)
                    .HasForeignKey(r => r.SubstantiveValueDomainId);*/
        }
    }
}