using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SvetulkaApp.Web.Services.Interfaces;

namespace SvetulkaApp.Web.Areas.Administration.Controllers
{
    public class OrdersController : AdministrationController
    {
        private readonly IOrdersService ordersService;
        private readonly IMapper mapper;

        public OrdersController(IOrdersService ordersService, IMapper mapper)
        {
            this.ordersService = ordersService;
            this.mapper = mapper;
        }

        public IActionResult Unprocess(int id)
        {
            this.ordersService.UnprocessOrder(id);

            return this.RedirectToAction("Index", "Home");
        }

        public IActionResult Process(int id)
        {
            this.ordersService.ShipOrder(id);

            return this.RedirectToAction("Index", "Home");
        }

        public IActionResult Deliver(int id)
        {
            this.ordersService.DeliverOrder(id);

            return this.RedirectToAction("Index", "Home");
        }

        //public IActionResult Details(int id)
        //{
        //    var order = this.ordersService.GetOrderById(id);
        //    if (order == null)
        //    {
        //        this.TempData["error"] = ERROR_MESSAGE_INVALID_ORDER_NUMBER;
        //        return this.RedirectToAction("Index", "Home");
        //    }
        //    var orderProducts = this.ordersService.OrderProductsByOrderId(id);

        //    var orderViewModel = this.mapper.Map<OrderDetailsViewModel>(order);
        //    var orderProductsViewModel = this.mapper.Map<IList<OrderProductsViewModel>>(orderProducts);

        //    orderViewModel.OrderProductsViewModel = orderProductsViewModel;

        //    return this.View(orderViewModel);
        //}

        //public IActionResult Delivered()
        //{
        //    var deliveredОrders = this.ordersService.GetDeliveredOrders();

        //    var deliveredОrdersViewModel = this.mapper.Map<IList<DeliveredОrdersViewModels>>(deliveredОrders);

        //    return View(deliveredОrdersViewModel);
        //}
    }
}
