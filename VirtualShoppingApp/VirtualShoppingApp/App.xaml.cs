using System;
using VirtualShoppingApp.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VirtualShoppingApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new ShoppingListPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
