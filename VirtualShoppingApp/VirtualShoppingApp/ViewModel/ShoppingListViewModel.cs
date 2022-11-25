using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VirtualShoppingApp.Model.Service;
using VirtualShoppingApp.Model;
using VirtualShoppingApp.ViewModel.Base;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;

namespace VirtualShoppingApp.ViewModel
{
    public class ShoppingListViewModel : BaseViewModel
    {
        public ObservableCollection<Category> ShoppingList { get; set; }
        public string Message { get; set; }
        public RelayCommand ApplyChangesCommand { get; set; }
        public RelayCommand<string> SearchCommand { get; set; }
        public RelayCommand<int> ChangeVisibilityCommand { get; set; }
        public RelayCommand<Category> RemoveCategoryCommand { get; set; }
        public RelayCommand<Product> RemoveProductCommand { get; set; }
        public bool IsBusy { get; set; }

        CategoryService categoryService;
        ProductService productService;
        public ShoppingListViewModel()
        {
            ShoppingList = new ObservableCollection<Category>();
            categoryService = new CategoryService();
            productService = new ProductService();

            ApplyChangesCommand = new RelayCommand(applyChanges);
            SearchCommand = new RelayCommand<string>(search);
            ChangeVisibilityCommand = new RelayCommand<int>(changeVisibility);
            RemoveCategoryCommand = new RelayCommand<Category>(deleteCategory);
            RemoveProductCommand = new RelayCommand<Product>(deleteProduct);

            loadData(null);

            MessagingCenter.Subscribe<AddOrEditProductViewModel, Product>(this, "AddOrEditProduct",
                (page, product) =>
                {
                    productService.addOrEditProduct(product);
                    loadData(null);
                });
            MessagingCenter.Subscribe<AddOrEditCategoryViewModel, Category>(this, "AddOrEditCategory",
                (page, category) =>
                {
                    categoryService.addOrEditCategory(category);
                    loadData(null);
                });
        }

        private void loadData(string query)
        {
            IsBusy = true;
            Task.Run(async () =>
            {
                try
                {
                    Thread.Sleep(1000);
                    if(query == null)
                        ShoppingList = new ObservableCollection<Category>(await categoryService.getShoppingListJoined());
                    else
                        ShoppingList = new ObservableCollection<Category>(await categoryService.getShoppingListSearched(query));
                    Message = "";
                }
                catch (Exception ex)
                {
                    Message = "Hiba: sikertelen betöltés!";
                    IsBusy = false;
                    throw ex;
                }
                IsBusy = false;
            });
        }

        private async void applyChanges()
        {
            IsBusy = true;
            await categoryService.setShoppingListChanges(ShoppingList.ToList());
            loadData(null);
        }

        private void search(string searchBlock)
        {
            loadData(searchBlock);
        }

        private void changeVisibility(int categoryID)
        {
            if (ShoppingList.FirstOrDefault(s => s.ID == categoryID).IsVisible)
                ShoppingList.FirstOrDefault(s => s.ID == categoryID).IsVisible = false;
            else
                ShoppingList.FirstOrDefault(s => s.ID == categoryID).IsVisible = true;
        }

        private void deleteCategory(Category category)
        {
            categoryService.removeCategory(category);
            Message = "Törlés sikeres!";
            loadData(null);
        }

        private void deleteProduct(Product product)
        {
            productService.removeProduct(product);
            Message = "Törlés sikeres!";
            loadData(null);
        }

        
    }
}
