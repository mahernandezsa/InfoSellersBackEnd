using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoSellers.Model.Entities
{
    public class InfoSellersContext : DbContext
    {
        public DbSet<BikeSeller> BikeSeller { get; set; }

        public DbSet<Role> Role { get; set; }

        public InfoSellersContext(DbContextOptions<InfoSellersContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BikeSeller>()
                .HasOne<Role>(b => b.Role)
                .WithOne(r => r.BikeSeller)
                .HasForeignKey<Role>(r => r.RoleOfBikeSellerId);

            modelBuilder.Entity<BikeSeller>()
                .Property(b => b.Status)
                .HasConversion<int>();

            modelBuilder.Entity<Role>()
                .Property(b => b.CommissionType)
                .HasConversion<string>();            
        }
    }
}