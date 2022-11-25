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
    public partial class AddOrEditCategoryPage : ContentPage
    {
        public AddOrEditCategoryPage(Category category)
        {
            InitializeComponent();
            BindingContext = new AddOrEditCategoryViewModel(category);
        }

        private void btnBackPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}