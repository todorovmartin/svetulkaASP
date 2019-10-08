using System;
using System.Collections.Generic;
using System.Text;

namespace SvetulkaApp.Web.ViewModels.Orders
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public DateTime OrderDate { get; set; }

        public IList<OrderProductsViewModel> OrderProductsViewModel { get; set; }
    }
}
