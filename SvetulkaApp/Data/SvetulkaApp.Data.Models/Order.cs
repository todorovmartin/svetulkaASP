// ReSharper disable VirtualMemberCallInConstructor
using SvetulkaApp.Data.Models.Enums;
using System;
using System.Collections.Generic;

namespace SvetulkaApp.Data.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public DateTime OrderedOn { get; set; }

        public OrderStatus Status { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}