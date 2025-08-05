using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ORMAdapter.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(250);
            builder.HasIndex(c => c.Title).IsUnique();

            builder.Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(c => c.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(c => c.OutgoingDocuments)
                .WithOne(od => od.Client)
                .HasForeignKey(od => od.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
