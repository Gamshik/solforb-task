using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ORMAdapter.Configurations
{
    public class OutgoingResourceConfiguration : IEntityTypeConfiguration<OutgoingResource>
    {
        public void Configure(EntityTypeBuilder<OutgoingResource> builder)
        {
            builder.HasKey(or => or.Id);
            builder.Property(or => or.Id).ValueGeneratedOnAdd();

            builder.Property(or => or.Quantity)
                .IsRequired();

            builder.HasOne(or => or.OutgoingDocument)
                .WithMany(d => d.OutgoingResources)
                .HasForeignKey(or => or.OutgoingDocumentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(or => or.Resource)
                .WithMany(r => r.OutgoingResources)
                .HasForeignKey(or => or.ResourceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(or => or.UnitOfMeasurement)
                .WithMany(u => u.OutgoingResources)
                .HasForeignKey(or => or.UnitOfMeasurementId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
