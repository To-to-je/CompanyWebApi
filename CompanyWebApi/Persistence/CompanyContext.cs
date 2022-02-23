
using CompanyWebApi.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using CompanyWebApi.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;


namespace CompanyWebApi.Persistence
{
    public class CompanyContext : DbContext
    {
        public DbSet<Company>? Companies { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<GroupType>? GroupTypes { get; set; }
        public DbSet<Appointment>? Appointments { get; set; }


        public CompanyContext(DbContextOptions<CompanyContext> options):base(options)
        {
            
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CompanyConfiguration().Configure(modelBuilder.Entity<Company>());
            new OrderConfiguration().Configure(modelBuilder.Entity<Order>());
            new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
            new AppointmentConfiguration().Configure(modelBuilder.Entity<Appointment>());
            new GroupTypeConfiguration().Configure(modelBuilder.Entity<GroupType>());
        }
    }

}

