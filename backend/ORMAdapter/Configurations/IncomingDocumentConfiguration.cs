using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ORMAdapter.Configurations
{
    public class IncomingDocumentConfiguration : IEntityTypeConfiguration<IncomingDocument>
    {
        public void Configure(EntityTypeBuilder<IncomingDocument> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).ValueGeneratedOnAdd();

            builder.Property(d => d.Number)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasIndex(d => d.Number).IsUnique();

            builder.Property(d => d.Date)
                .IsRequired();

            builder.HasMany(d => d.IncomingResources)
                .WithOne(ir => ir.IncomingDocument)
                .HasForeignKey(ir => ir.IncomingDocumentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
