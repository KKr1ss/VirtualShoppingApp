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
        public CategoryService()
        {
            _context = new ShoppingContext();
        }
        public CategoryService(ShoppingContext context)
        {
            _context = context;
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
            catch (Exception ex)
            {
                throw ex;
            }
            return await Task.FromResult(categoriesJoined);
        }
    }
}
