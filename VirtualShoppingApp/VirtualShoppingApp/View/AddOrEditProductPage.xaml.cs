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
    public partial class AddOrEditProductPage : ContentPage
    {
        public AddOrEditProductPage(Product product)
        {
            InitializeComponent();
            BindingContext = new AddOrEditProductViewModel(product);
        }

        private void btnBackPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}