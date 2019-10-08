using Microsoft.EntityFrameworkCore;
using SvetulkaApp.Data;
using SvetulkaApp.Data.Models;
using SvetulkaApp.Data.Models.Enums;
using SvetulkaApp.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SvetulkaApp.Web.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IUsersService userService;
        private readonly IShoppingCartService shoppingCartService;
        private readonly SvetulkaDbContext db;

        public OrdersService(IUsersService userService, IShoppingCartService shoppingCartService, SvetulkaDbContext db)
        {
            this.userService = userService;
            this.shoppingCartService = shoppingCartService;
            this.db = db;
        }

        public Order CreateOrder(string username)
        {
            var user = this.userService.GetUserByUsername(username);

            var order = new Order
            {
                Status = OrderStatus.Ordered,
                User = user,
                OrderedOn = DateTime.UtcNow.AddHours(2),
            };

            // creating order product
            var shoppingCartProducts = this.shoppingCartService.GetAllShoppingCartProducts(username).ToList();

            List<OrderProduct> orderProducts = new List<OrderProduct>();

            foreach (var shoppingCartProduct in shoppingCartProducts)
            {
                var orderProduct = new OrderProduct
                {
                    Order = order,
                    Product = shoppingCartProduct.Product,
                };

                orderProducts.Add(orderProduct);
            }

            this.shoppingCartService.DeleteAllProductsFromShoppingCart(username);

            order.OrderedOn = DateTime.UtcNow.AddHours(2);
            order.Status = OrderStatus.Ordered;
            order.OrderProducts = orderProducts;

            this.db.Orders.Add(order);
            this.db.SaveChanges();

            return order;
        }

        public void DeliverOrder(int id)
        {
            var order = this.db.Orders.FirstOrDefault(x => x.Id == id
                                            && x.Status == OrderStatus.Shipped);

            if (order == null)
            {
                return;
            }

            order.Status = OrderStatus.Delivered;
            this.db.SaveChanges();
        }

        public IEnumerable<Order> GetDeliveredOrders()
        {
            var orders = this.db.Orders.Include(x => x.OrderProducts)
                                      .Where(x => x.Status == OrderStatus.Delivered);

            return orders;
        }

        public Order GetOrderById(int orderId)
        {
            return this.db.Orders.Include(x => x.User)
                                 .FirstOrDefault(x => x.Id == orderId);
        }

        public IEnumerable<Order> GetShippedOrders()
        {
            var orders = this.db.Orders.Include(x => x.OrderProducts)
                                       .Where(x => x.Status == OrderStatus.Shipped);

            return orders;
        }

        public IEnumerable<Order> GetUnprocessedOrders()
        {
            var orders = this.db.Orders.Include(x => x.OrderProducts)
                                       .Where(x => x.Status == OrderStatus.Ordered);

            return orders;
        }

        public IEnumerable<Order> GetUserOrders(string username)
        {
            var order = this.db.Orders.Where(x => x.User.UserName == username).ToList();

            return order;
        }

        public IEnumerable<OrderProduct> OrderProductsByOrderId(int id)
        {
            return this.db.OrderProducts.Include(x => x.Product)
                                        .Where(x => x.OrderId == id).ToList();
        }

        public void ShipOrder(int id)
        {
            var order = this.db.Orders.FirstOrDefault(x => x.Id == id &&
                                        (x.Status == OrderStatus.Ordered || x.Status == OrderStatus.Delivered));

            if (order == null)
            {
                return;
            }

            order.Status = OrderStatus.Shipped;
            this.db.SaveChanges();
        }

        public void UnprocessOrder(int id)
        {
            var order = this.db.Orders.FirstOrDefault(x => x.Id == id);

            if (order == null)
            {
                return;
            }

            order.Status = OrderStatus.Ordered;
            this.db.SaveChanges();
        }

        public Order GetProcessingOrder(string username)
        {
            var user = this.userService.GetUserByUsername(username);

            if (user == null)
            {
                return null;
            }

            var order = this.db.Orders.Include(x => x.OrderProducts)
                                      .FirstOrDefault(x => x.User.UserName == username && x.Status == OrderStatus.Shipped);

            return order;
        }
    }
}
