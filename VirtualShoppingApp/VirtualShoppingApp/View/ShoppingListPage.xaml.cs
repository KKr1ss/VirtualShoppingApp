using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualShoppingApp.Model;
using VirtualShoppingApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VirtualShoppingApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShoppingListPage : ContentPage
    {
        public ShoppingListPage()
        {
            InitializeComponent();
            BindingContext = new ShoppingListViewModel();
        }

        private void btnAddProduct_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var parameter = button.CommandParameter;
            Product productToSend = parameter is Product ? productToSend = (Product)parameter 
                : productToSend = new Product
            {
                CategoryID = (int)parameter
            };

            Navigation.PushAsync(new AddOrEditProductPage(productToSend));
        }

        private void btnAddCategory_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var parameter = button.CommandParameter;
            Category categoryToSend = parameter == null ? new Category() : (Category)parameter;

            Navigation.PushAsync(new AddOrEditCategoryPage(categoryToSend));
        }
    }
}