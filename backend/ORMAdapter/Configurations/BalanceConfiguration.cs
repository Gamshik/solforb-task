using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ORMAdapter.Configurations
{
    public class BalanceConfiguration : IEntityTypeConfiguration<Balance>
    {
        public void Configure(EntityTypeBuilder<Balance> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.Property(b => b.Quantity)
                .IsRequired();

            builder.HasIndex(b => new { b.ResourceId, b.UnitOfMeasurementId })
                .IsUnique();

            builder.HasOne(b => b.Resource)
                .WithMany(r => r.Balances)
                .HasForeignKey(b => b.ResourceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.UnitOfMeasurement)
                .WithMany(u => u.Balances)
                .HasForeignKey(b => b.UnitOfMeasurementId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
