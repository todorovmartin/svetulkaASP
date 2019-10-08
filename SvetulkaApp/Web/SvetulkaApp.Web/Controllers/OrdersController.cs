using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SvetulkaApp.Data.Models;
using SvetulkaApp.Web.Services.Interfaces;
using SvetulkaApp.Web.ViewModels.Orders;
using System.Collections.Generic;
using System.Linq;

namespace SvetulkaApp.Web.Controllers
{
    [Authorize]
    public class OrdersController : BaseController
    {
        private readonly IUsersService userService;
        private readonly IOrdersService orderService;
        private readonly IShoppingCartService shoppingCartService;
        private readonly IMapper mapper;

        public OrdersController(IUsersService userService, IOrdersService orderService, IShoppingCartService shoppingCartService, IMapper mapper)
        {
            this.userService = userService;
            this.orderService = orderService;
            this.shoppingCartService = shoppingCartService;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(int asdd)
        {
            var order = this.orderService.CreateOrder(this.User.Identity.Name);
            return this.RedirectToAction("Index", "ShoppingCart");
        }

        public IActionResult MyOrders(int id)
        {
            IEnumerable<Order> orders = this.orderService.GetUserOrders(this.User.Identity.Name).OrderByDescending(x => x.Id);

            var model = this.mapper.Map<IList<MyOrdersViewModel>>(orders);

            return this.View(model);
        }

        public IActionResult Details(int id)
        {
            var order = this.orderService.GetOrderById(id);

            var orderProducts = this.orderService.OrderProductsByOrderId(id);

            var orderViewModel = this.mapper.Map<OrderDetailsViewModel>(order);
            var orderProductsViewModel = this.mapper.Map<IList<OrderProductsViewModel>>(orderProducts);
            orderViewModel.OrderProductsViewModel = orderProductsViewModel;

            return this.View(orderViewModel);
        }
    }
}
