using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SvetulkaApp.Web.Areas.Administration.ViewModels.Home
{
    public class IndexViewModel
    {
        public IList<ShippedOrdersViewModel> ShippedOrdersViewModel { get; set; }

        public IList<UnprocessedOrdersViewModel> UnprocessedОrdersViewModel { get; set; }

        public IList<DeliveredOrdersViewModel> DeliveredOrdersViewModel { get; set; }

        public int PartnerRequestsCount { get; set; }
    }
}
