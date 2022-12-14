using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualShoppingApp.Data;

namespace VirtualShoppingApp.Model.Service
{
    public class ProductService
    {
        ShoppingContext _context;
        public ProductService()
        {
            _context = new ShoppingContext();
        }
        public ProductService(ShoppingContext context)
        {
            _context = context;
        }

        public List<Product> getProducts()
        {
            return _context.Products.ToList();
        }

        public bool addOrEditProduct(Product product)
        {
            bool isSaved = false;
            try
            {
                if (product.ID == 0)
                    _context.Products.Add(product);
                else
                {
                    var productToUpdate = _context.Products.First(p => p.ID == product.ID);
                    productToUpdate.AuthorName = product.AuthorName;
                    productToUpdate.ProductName = product.ProductName;
                    productToUpdate.Quantity = product.Quantity;
                    productToUpdate.IsReady = product.IsReady;
                }
                _context.SaveChanges();
                isSaved = true;
            }
            catch (Exception)
            {
                throw;
            }
            
            return isSaved;
        }

        public bool removeProduct(Product product)
        {
            bool isSaved = false;
            try
            {
                _context.Products.Remove(_context.Products.FirstOrDefault(p=>p.ID == product.ID));
                _context.SaveChanges();
                isSaved = true;
            }
            catch (Exception)
            {
                throw;
            }
            return isSaved;
        }

        public List<Product> getEveryProductFromShoppingList(List<Category> shoppingList)
        {
            List<Product> products = new List<Product>();
            foreach (var category in shoppingList)
            {
                products.AddRange(category.Products);
            }
            return products;
        }

        public async Task<bool> setProductChanges(List<Product> productsToUpdate)
        {
            bool isSaved = false;
            try
            {
                foreach (Product product in productsToUpdate)
                {
                    var productToUpdate = await _context.Products.FirstOrDefaultAsync(p => p.ID == product.ID);
                    productToUpdate.CategoryID = product.CategoryID;
                    productToUpdate.ProductName = product.ProductName;
                    productToUpdate.AuthorName = product.AuthorName;
                    productToUpdate.Quantity = product.Quantity;
                    productToUpdate.IsReady = product.IsReady;
                }
                await _context.SaveChangesAsync();
                isSaved = true;
            }
            catch (Exception)
            {
                throw;
            }
            return isSaved;
        }
    }
}
