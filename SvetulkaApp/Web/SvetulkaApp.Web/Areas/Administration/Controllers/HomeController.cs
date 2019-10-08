using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SvetulkaApp.Web.Areas.Administration.ViewModels.Home;
using SvetulkaApp.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SvetulkaApp.Web.Areas.Administration.Controllers
{
    public class HomeController : AdministrationController
    {
        private readonly IOrdersService ordersService;
        private readonly IMapper mapper;

        public HomeController(IOrdersService ordersService, IMapper mapper)
        {
            this.ordersService = ordersService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var unprocessedОrders = this.ordersService.GetUnprocessedOrders();
            var shippedOrders = this.ordersService.GetShippedOrders();
            var deliveredOrders = this.ordersService.GetDeliveredOrders();

            var unprocessedОrdersViewModel = this.mapper.Map<IList<UnprocessedOrdersViewModel>>(unprocessedОrders);
            var processedОrdersViewModel = this.mapper.Map<IList<ShippedOrdersViewModel>>(shippedOrders);
            var deliveredOrdersViewModel = this.mapper.Map<IList<DeliveredOrdersViewModel>>(deliveredOrders);

            var viewModel = new IndexViewModel
            {
                UnprocessedОrdersViewModel = unprocessedОrdersViewModel,
                ShippedOrdersViewModel = processedОrdersViewModel,
                DeliveredOrdersViewModel = deliveredOrdersViewModel,
            };

            return this.View(viewModel);
        }
    }
}
