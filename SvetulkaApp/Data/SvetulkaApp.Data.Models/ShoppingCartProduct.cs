﻿// ReSharper disable VirtualMemberCallInConstructor
namespace SvetulkaApp.Data.Models
{
    public class ShoppingCartProduct
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int ShoppingCartId { get; set; }

        public ShoppingCart ShoppingCart { get; set; }
    }
}