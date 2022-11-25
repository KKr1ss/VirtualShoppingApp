using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualShoppingApp.Model;
using VirtualShoppingApp.ViewModel.Base;
using Xamarin.Forms;

namespace VirtualShoppingApp.ViewModel
{
    public class AddOrEditProductViewModel
    {
        public RelayCommand SendMessageCommand { get; set; }
        public Product ActualProduct { get; set; }
        public AddOrEditProductViewModel(Product product)
        {
            ActualProduct = product;
            SendMessageCommand = new RelayCommand(sendMessage);
        }

        private void sendMessage()
        {
            MessagingCenter.Send(this, "AddOrEditProduct", ActualProduct);
        }
    }
}
