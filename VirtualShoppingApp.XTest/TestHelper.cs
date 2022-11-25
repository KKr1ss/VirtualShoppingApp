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

            testContext.Categories.AddRange(getTestCategories());
            testContext.Products.AddRange(getTestProducts());

            testContext.SaveChanges();

            return testContext;
        }

        public static List<Category> getTestJoinedShopplingList()
        {
            var testCategories = getTestCategories();
            var testProducts = getTestProducts();
            foreach(Category category in testCategories)
            {
                category.Products = testProducts.Where(tp => tp.CategoryID == category.ID).ToList();
            }
            return testCategories;
        }

        public static List<Category> getTestCategories()
        {
            var testCategories = new List<Category>()
            {
                new Category
                {
                    ID = 1,
                    CategoryName = "Elektronika",
                    CreatedDate = new DateTime(2022,11,25),
                    IsReady = false
                },
                new Category
                {
                    ID = 2,
                    CategoryName = "Élelmiszer",
                    CreatedDate = new DateTime(2022,11,24),
                    IsReady = true
                },
                new Category
                {
                    ID = 3,
                    CategoryName = "Műszaki",
                    CreatedDate = new DateTime(2022,11,25),
                    IsReady = false
                },
                new Category
                {
                    ID = 4,
                    CategoryName = "Hallucinogén szerek amelyet nem veszünk",
                    CreatedDate = new DateTime(2022,11,22),
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
            };
            return testCategories;
        }

        public static List<Product> getTestProducts()
        {
            var testProducts = new List<Product>()
            {
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
            };
            return testProducts;
        }
    }
}
