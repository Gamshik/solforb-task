using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ORMAdapter.Configurations
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();

            builder.Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(200);
            builder.HasIndex(r => r.Title).IsUnique();

            builder.Property(r => r.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(r => r.Balances)
                .WithOne(b => b.Resource)
                .HasForeignKey(b => b.ResourceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(r => r.IncomingResources)
                .WithOne(ir => ir.Resource)
                .HasForeignKey(ir => ir.ResourceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(r => r.OutgoingResources)
                .WithOne(or => or.Resource)
                .HasForeignKey(or => or.ResourceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
