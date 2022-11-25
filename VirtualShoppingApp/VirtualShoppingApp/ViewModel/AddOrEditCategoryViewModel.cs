using System;
using System.Collections.Generic;
using System.Text;
using VirtualShoppingApp.Model;
using VirtualShoppingApp.ViewModel.Base;
using Xamarin.Forms;

namespace VirtualShoppingApp.ViewModel
{
    public class AddOrEditCategoryViewModel
    {
        public RelayCommand SendMessageCommand { get; set; }
        public Category ActualCategory { get; set; }
        public AddOrEditCategoryViewModel(Category category)
        {
            ActualCategory = category;
            SendMessageCommand = new RelayCommand(sendMessage);
        }

        private void sendMessage()
        {
            MessagingCenter.Send(this, "AddOrEditCategory", ActualCategory);
        }
    }
}
