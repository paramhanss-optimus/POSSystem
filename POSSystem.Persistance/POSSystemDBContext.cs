using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POSSystem.Domain.Entities;
using POSSystem.Persistance.Configurations;

namespace POSSystem.Persistance
{
    public class POSSystemDBContext : DbContext
    {
        public POSSystemDBContext(DbContextOptions<POSSystemDBContext> options) : base(options)
        {
        }

        public DbSet<AdminEntity> Admins { get; set; }
        public DbSet<CashierEntity> Cashiers { get; set; }

        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<InventoryEntity> Inventories { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<ReportEntity> Reports { get; set; }
        public DbSet<OrderInventory> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdminEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CashierEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ReportEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderProductConfiguration());

            //modelBuilder.Entity<UserEntity>().HasData(
            //    new UserEntity  {Email = "admin@gmail.com", Password = "admin", Role = "admin"},
            //    new UserEntity { Email = "cashier@gmail.com", Password = "cashier", Role = "cashier" }
            //);

        }


    }
}
