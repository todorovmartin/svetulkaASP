using System;
using System.Collections.Generic;
using System.Text;

namespace SvetulkaApp.Web.ViewModels.Orders
{
    public class OrderProductsViewModel
    {
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
