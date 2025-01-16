using Database.TableModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.DatabaseConnection
{
    public class BuyingHouseDB : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-GDKI8TK\SQLEXPRESS;Database=BuyingHouseManagementSystem;Trusted_Connection=True;TrustServerCertificate=True;ConnectRetryCount=0");
        }

        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Size> Size { get; set; }
        public DbSet<Price> Price { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Brand> Brand { get; set; }

    }
}
