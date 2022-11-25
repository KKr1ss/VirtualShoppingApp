using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Text;
using VirtualShoppingApp.Helper;
using VirtualShoppingApp.Model;

namespace VirtualShoppingApp.Data
{
    public class ShoppingContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public ShoppingContext()
        {
            this.Database.EnsureCreated();
        }

        public ShoppingContext(DbContextOptions<ShoppingContext> options) : base(options)
        {
            this.Database.EnsureCreated();
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;
            string dbPath = Path.Combine(Constants.Path, "VirtualShoppings.db3");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
