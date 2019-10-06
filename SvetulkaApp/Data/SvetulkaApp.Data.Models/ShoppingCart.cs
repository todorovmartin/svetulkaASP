// ReSharper disable VirtualMemberCallInConstructor
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SvetulkaApp.Data.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<ShoppingCartProduct> ShoppingCartProducts { get; set; }
    }
}