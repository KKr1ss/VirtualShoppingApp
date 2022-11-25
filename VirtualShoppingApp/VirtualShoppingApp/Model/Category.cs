using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VirtualShoppingApp.ViewModel.Base;

namespace VirtualShoppingApp.Model
{
    public class Category : BaseViewModel
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsReady { get; set; }
        [NotMapped]
        public List<Product> Products { get; set; }
        [NotMapped]
        public bool IsVisible { get; set; }
    }
}
