using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualShoppingApp.Data;

namespace VirtualShoppingApp.Model.Service
{
    public class CategoryService
    {
        ShoppingContext _context;
        ProductService productService;
        public CategoryService()
        {
            _context = new ShoppingContext();
            productService = new ProductService();
        }
        public CategoryService(ShoppingContext context)
        {
            _context = context;
            productService = new ProductService(context);
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public bool addOrEditCategory(Category category)
        {
            bool isSaved = false;
            try
            {
                if (category.ID == 0)
                {
                    category.CreatedDate = DateTime.Now;
                    _context.Categories.Add(category);
                } 
                else
                {
                    var categoryToUpdate = _context.Categories.First(c => c.ID == category.ID);
                    categoryToUpdate.CategoryName = category.CategoryName;
                    categoryToUpdate.CreatedDate = category.CreatedDate;
                    categoryToUpdate.IsReady = category.IsReady;
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

        public bool removeCategory(Category category)
        {
            bool isSaved = false;
            try
            {
                var productsToRemove = _context.Products.Where(p => p.CategoryID == category.ID).ToList();
                
                foreach(var product in productsToRemove)
                {
                    productService.removeProduct(product);
                }
                _context.Categories.Remove(_context.Categories.FirstOrDefault(c => c.ID == category.ID));
                _context.SaveChanges();
                isSaved = true;
            }
            catch (Exception)
            {
                throw;
            }
            return isSaved;
        }

        public async Task<List<Category>> getShoppingListSearched(string query)
        {
            List<Category> shoppingListResult = new List<Category>();
            try
            {
                var shoppingListSearched = new List<Category>();

                foreach(Category category in await getShoppingListJoined())
                {
                    if (category.Products.Any(p => p.ProductName.ToLower().Contains(query.ToLower())))
                    {
                        category.Products = category.Products.Where(p => p.ProductName.ToLower().Contains(query.ToLower())).ToList();
                        shoppingListSearched.Add(category);
                    }
                }
                shoppingListResult = shoppingListSearched;
            }
            catch (Exception)
            {
                throw;
            }
            return await Task.FromResult(shoppingListResult);
        }

        public async Task<List<Category>> getShoppingListJoined()
        {
            List<Category> categoriesJoined = new List<Category>();
            try
            {
                var taskCategories = _context.Categories.ToListAsync();
                var taskProducts = _context.Products.ToListAsync();

                List<Category> categories = await taskCategories;
                List<Product> products = await taskProducts;

                foreach (var category in categories)
                {
                    category.Products = products.Where(p => p.CategoryID == category.ID).ToList();
                }
                categoriesJoined.AddRange(categories);
            }
            catch (Exception)
            {
                throw;
            }
            return await Task.FromResult(categoriesJoined);
        }

        public async Task<bool> setShoppingListChanges(List<Category> shoppingListToUpdate)
        {
            bool isSaved = false;
            try
            {
                await setCategoryChanges(shoppingListToUpdate);
                var products = productService.getEveryProductFromShoppingList(shoppingListToUpdate);
                await productService.setProductChanges(products);
                
                isSaved = true;
            }
            catch (Exception)
            {
                throw;
            }
            return isSaved;
        }

        public async Task<bool> setCategoryChanges(List<Category> categoriesToUpdate)
        {
            bool isSaved = false;
            try
            {
                foreach (Category category in categoriesToUpdate)
                {
                    var categoryToUpdate = await _context.Categories.FirstOrDefaultAsync(c => c.ID == category.ID);
                    categoryToUpdate.CreatedDate = category.CreatedDate;
                    categoryToUpdate.CategoryName = category.CategoryName;
                    categoryToUpdate.IsReady = category.IsReady;
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
