using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SvetulkaApp.Web.Services.Interfaces;
using SvetulkaApp.Web.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SvetulkaApp.Web.Components
{
    public class OrderProductsComponent : ViewComponent
    {
        private readonly IOrdersService ordersService;
        private readonly IMapper mapper;

        public OrderProductsComponent(IOrdersService ordersService, IMapper mapper)
        {
            this.ordersService = ordersService;
            this.mapper = mapper;
        }

        public IViewComponentResult Invoke(int orderId)
        {
            var orderProducts = this.ordersService.OrderProductsByOrderId(orderId);

            var orderProductsViewModel = this.mapper.Map<IList<OrderProductsViewModel>>(orderProducts);

            return this.View(orderProductsViewModel);
        }
    }
}
