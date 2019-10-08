using SvetulkaApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SvetulkaApp.Web.Services.Interfaces
{
    public interface IOrdersService
    {
        Order CreateOrder(string username);

        Order GetOrderById(int orderId);

        void UnprocessOrder(int id);

        void ShipOrder(int id);

        void DeliverOrder(int id);

        IEnumerable<Order> GetUserOrders(string name);

        IEnumerable<Order> GetUnprocessedOrders();

        IEnumerable<Order> GetShippedOrders();

        IEnumerable<Order> GetDeliveredOrders();

        IEnumerable<OrderProduct> OrderProductsByOrderId(int id);

        Order GetProcessingOrder(string username);

        // Order GetUserOrderById(int orderId, string username);
    }
}
