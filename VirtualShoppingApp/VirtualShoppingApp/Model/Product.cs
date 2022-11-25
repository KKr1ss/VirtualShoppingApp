using System;
using System.Collections.Generic;
using System.Text;
using VirtualShoppingApp.ViewModel.Base;

namespace VirtualShoppingApp.Model
{
    public class Product : BaseViewModel
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public string AuthorName { get; set; }
        public string Quantity { get; set; }
        public bool IsReady { get; set; }
    }
}
