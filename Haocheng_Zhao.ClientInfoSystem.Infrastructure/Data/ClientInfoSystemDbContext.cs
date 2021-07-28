using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haocheng_Zhao.ClientInfoSystem.Infrastructure.Data
{
    public class ClientInfoSystemDbContext: DbContext
    {

        public ClientInfoSystemDbContext(DbContextOptions<ClientInfoSystemDbContext> options):base(options)
        {

        }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Interactions> Interactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clients>(ConfigureClients);
            modelBuilder.Entity<Employees>(ConfigureEmployees);
            modelBuilder.Entity<Interactions>(ConfigureInteractions);
        }

        private void ConfigureEmployees(EntityTypeBuilder<Employees> obj)
        {
            obj.HasKey(e => e.Id);
            obj.Property(e => e.Name).HasMaxLength(50);
            obj.Property(u => u.Password).HasMaxLength(1024);
            obj.Property(u => u.Salt).HasMaxLength(1024);
            obj.Property(e => e.Designation).HasMaxLength(50);
        }

        private void ConfigureInteractions(EntityTypeBuilder<Interactions> obj)
        {
            obj.HasKey(i => i.Id);
            obj.Property(i => i.IntType).HasMaxLength(1);
            obj.Property(i => i.Remarks).HasMaxLength(500);

        }

        private void ConfigureClients(EntityTypeBuilder<Clients> obj)
        {
            obj.HasKey(i => i.Id);
            obj.Property(e => e.Name).HasMaxLength(50);
            obj.Property(e => e.Email).HasMaxLength(50);
            obj.Property(e => e.Phones).HasMaxLength(30);
            obj.Property(e => e.Address).HasMaxLength(50);
        }
    }
}
