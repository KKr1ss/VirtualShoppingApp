using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualShoppingApp.Data;
using VirtualShoppingApp.Model;

namespace VirtualShoppingApp.Test
{
    public class TestHelper
    {
        public static ShoppingContext getFilledShoppingContext()
        {
            var conn = new SqliteConnection("DataSource=:memory:");
            conn.Open(); // open connection to use
            var options = new DbContextOptionsBuilder<ShoppingContext>()
               .UseSqlite(conn)
               .Options;
            ShoppingContext testContext = new ShoppingContext(options);
            
            testContext.Categories.AddRange(
                new Category
                {
                    ID = 1,
                    CategoryName = "Elektronika",
                    CreatedDate = DateTime.Now,
                    IsReady = false
                },
                new Category
                {
                    ID = 2,
                    CategoryName = "Élelmiszer",
                    CreatedDate = DateTime.Now,
                    IsReady = true
                },
                new Category
                {
                    ID = 3,
                    CategoryName = "Műszaki",
                    CreatedDate = DateTime.Now,
                    IsReady = false
                }
                //new Store
                //{
                //    ID = ,
                //    CategoryName = "",
                //    AuthorName = "",
                //    CreatedDate = DateTime.Now,
                //    IsReady = false
                //}
            );

            testContext.Products.AddRange(
                new Product()
                {
                    ID = 1,
                    CategoryID = 1,
                    ProductName = "Hosszabbító",
                    AuthorName = "Krisz",
                    Quantity = "1 db",
                    IsReady = false
                },
                new Product()
                {
                    ID = 2,
                    CategoryID = 2,
                    ProductName = "Húspogácsa",
                    AuthorName = "Krisz",
                    Quantity = "10 db",
                    IsReady = true
                },
                new Product()
                {
                    ID = 3,
                    CategoryID = 2,
                    ProductName = "Sültkrumpli",
                    AuthorName = "Kinga",
                    Quantity = "1 kg",
                    IsReady = false
                },
                new Product()
                {
                    ID = 4,
                    CategoryID = 3,
                    ProductName = "Csavarhúzó",
                    AuthorName = "Krisz",
                    Quantity = "1 db",
                    IsReady = true
                },
                new Product()
                {
                    ID = 5,
                    CategoryID = 3,
                    ProductName = "Fűrész",
                    AuthorName = "Kinga",
                    Quantity = "1 db",
                    IsReady = false
                },
                new Product()
                {
                    ID = 6,
                    CategoryID = 2,
                    ProductName = "Csirkemell",
                    AuthorName = "Kinga",
                    Quantity = "500 g",
                    IsReady = false
                }
                //new Product()
                //{
                //    ID = ,
                //    StoreID = ,
                //    ProductName = "",
                //    AuthorName = "",
                //    Quantity = ,
                //    IsReady = false
                //}
            );

            testContext.SaveChanges();

            return testContext;
        }
    }
}
