// ReSharper disable VirtualMemberCallInConstructor
using System.Collections.Generic;

namespace SvetulkaApp.Data.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<ShoppingCartProduct> ShoppingCartProducts { get; set; }
    }
}