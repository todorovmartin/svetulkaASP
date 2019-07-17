using SvetulkaApp.Data.Models.Enums;
using System;
using System.Collections.Generic;

namespace SvetulkaApp.Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public int Quantity { get; set; }

        public DateTime? DateAdded { get; set; }

        public bool IsInStock { get; set; }

        public Tag Tag { get; set; }

        public ProductCategory Category { get; set; }

        public ICollection<ProductTag> ProductTags { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }

        public ICollection<FavoriteProduct> FavoriteProducts { get; set; }

        public ICollection<ShoppingCartProduct> ShoppingCartProducts { get; set; }
    }
}
