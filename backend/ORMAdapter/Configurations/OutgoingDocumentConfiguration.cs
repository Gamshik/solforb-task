using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Enums;

namespace ORMAdapter.Configurations
{
    public class OutgoingDocumentConfiguration : IEntityTypeConfiguration<OutgoingDocument>
    {
        public void Configure(EntityTypeBuilder<OutgoingDocument> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).ValueGeneratedOnAdd();

            builder.Property(d => d.Number)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasIndex(d => d.Number).IsUnique();

            builder.Property(d => d.Date)
                .IsRequired();

            builder.Property(d => d.Status)
                .IsRequired()
                .HasDefaultValue(DocumentStatus.Unsigned);

            builder.HasOne(d => d.Client)
                .WithMany(c => c.OutgoingDocuments)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d => d.OutgoingResources)
                .WithOne(or => or.OutgoingDocument)
                .HasForeignKey(or => or.OutgoingDocumentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
