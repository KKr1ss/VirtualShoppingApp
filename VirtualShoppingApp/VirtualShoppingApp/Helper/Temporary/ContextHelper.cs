using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtualShoppingApp.Data;
using VirtualShoppingApp.Model;

namespace VirtualShoppingApp.Helper.Temporary
{
    public class ContextHelper
    {
        public static void fillContext()
        {
            ShoppingContext _context = new ShoppingContext();
            _context.Categories.RemoveRange(_context.Categories.ToList());
            _context.Products.RemoveRange(_context.Products.ToList());

            _context.Categories.AddRange(
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
                },
                new Category
                {
                    ID = 4,
                    CategoryName = "Nem megbízható bolt",
                    CreatedDate = new DateTime(2022, 11, 22),
                    IsReady = false
                }
            );

            _context.Products.AddRange(
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
            );

            _context.SaveChanges();
        }
    }
}
