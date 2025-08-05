using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ORMAdapter.Configurations
{
    public class UnitOfMeasurementConfiguration : IEntityTypeConfiguration<UnitOfMeasurement>
    {
        public void Configure(EntityTypeBuilder<UnitOfMeasurement> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            builder.Property(u => u.Title)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasIndex(u => u.Title).IsUnique();

            builder.Property(u => u.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(u => u.Balances)
                .WithOne(b => b.UnitOfMeasurement)
                .HasForeignKey(b => b.UnitOfMeasurementId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.IncomingResources)
                .WithOne(ir => ir.UnitOfMeasurement)
                .HasForeignKey(ir => ir.UnitOfMeasurementId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.OutgoingResources)
                .WithOne(or => or.UnitOfMeasurement)
                .HasForeignKey(or => or.UnitOfMeasurementId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
