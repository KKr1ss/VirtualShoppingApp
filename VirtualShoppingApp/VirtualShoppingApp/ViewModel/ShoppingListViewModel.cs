using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VirtualShoppingApp.Model.Service;
using VirtualShoppingApp.Model;
using VirtualShoppingApp.ViewModel.Base;
using VirtualShoppingApp.Helper.Temporary;
using System.Threading;
using System.Threading.Tasks;

namespace VirtualShoppingApp.ViewModel
{
    public class ShoppingListViewModel : BaseViewModel
    {
        public ObservableCollection<Category> ShoppingList { get; set; }
        public Category SelectedCategory { get; set; }
        public Product SelectedProduct { get; set; }
        public string Message { get; set; }
        public RelayCommand ApplyChangesCommand { get; set; }
        public bool IsBusy { get; set; }

        CategoryService categoryService;
        public ShoppingListViewModel()
        {
            ShoppingList = new ObservableCollection<Category>();

            categoryService = new CategoryService();
            ApplyChangesCommand = new RelayCommand(applyChanges);
            loadData();
        }

        private void loadData()
        {
            IsBusy = true;
            Task.Run(async () =>
            {
                try
                {
                    Thread.Sleep(2000);
                    ShoppingList = new ObservableCollection<Category>(await categoryService.getShoppingListJoined());
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

        private void applyChanges()
        {

        }
    }
}
