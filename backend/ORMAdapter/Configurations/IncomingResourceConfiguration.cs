using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ORMAdapter.Configurations
{
    public class IncomingResourceConfiguration : IEntityTypeConfiguration<IncomingResource>
    {
        public void Configure(EntityTypeBuilder<IncomingResource> builder)
        {
            builder.HasKey(ir => ir.Id);
            builder.Property(ir => ir.Id).ValueGeneratedOnAdd();

            builder.Property(ir => ir.Quantity)
                .IsRequired();

            builder.HasOne(ir => ir.IncomingDocument)
                .WithMany(d => d.IncomingResources)
                .HasForeignKey(ir => ir.IncomingDocumentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ir => ir.Resource)
                .WithMany(r => r.IncomingResources)
                .HasForeignKey(ir => ir.ResourceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ir => ir.UnitOfMeasurement)
                .WithMany(u => u.IncomingResources)
                .HasForeignKey(ir => ir.UnitOfMeasurementId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
