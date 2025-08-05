using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace ORMAdapter.Contexts
{
    public class WarehouseDbContext : DbContext
    {
        public DbSet<Resource> Resources { get; set; }
        public DbSet<UnitOfMeasurement> UnitsOfMeasurement { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<IncomingDocument> IncomingDocuments { get; set; }
        public DbSet<IncomingResource> IncomingResources { get; set; }
        public DbSet<OutgoingDocument> OutgoingDocuments { get; set; }
        public DbSet<OutgoingResource> OutgoingResources { get; set; }

        public WarehouseDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WarehouseDbContext).Assembly);
        }
    }
}
