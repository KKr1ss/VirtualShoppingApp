using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VirtualShoppingApp.Model.Service;
using VirtualShoppingApp.Model;
using VirtualShoppingApp.ViewModel.Base;
using VirtualShoppingApp.Helper.Temporary;

namespace VirtualShoppingApp.ViewModel
{
    public class ShoppingListViewModel : BaseViewModel
    {
        public ObservableCollection<Category> ShoppingList { get; set; }
        public Category SelectedCategory { get; set; }
        public Product SelectedProduct { get; set; }
        public string Message { get; set; }
        CategoryService categoryService;
        public ShoppingListViewModel()
        {
            categoryService = new CategoryService();
            loadData();
        }

        private async void loadData()
        {
            var newShoppingList = new ObservableCollection<Category>();
            try
            {
                newShoppingList = new ObservableCollection<Category>(await categoryService.getShoppingListJoined());
            }
            catch (Exception ex)
            {
                Message = "Sikertelen betöltés";
                throw ex;
            }
            ShoppingList = newShoppingList;
        }
    }
}
