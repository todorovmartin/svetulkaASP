using System;
using System.Collections.Generic;
using System.Text;

namespace SvetulkaApp.Web.ViewModels.ShoppingCart
{
    public class ShoppingCartViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
