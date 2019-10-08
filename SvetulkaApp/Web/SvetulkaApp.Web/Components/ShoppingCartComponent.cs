using Microsoft.AspNetCore.Mvc;
using SvetulkaApp.Web.Services.Interfaces;
using SvetulkaApp.Web.ViewModels.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SvetulkaApp.Web.Components
{
    public class ShoppingCartComponent : ViewComponent
    {
        private IShoppingCartService shoppingCartService;

        public ShoppingCartComponent(IShoppingCartService shoppingCartService)
        {
            this.shoppingCartService = shoppingCartService;
        }

        public IViewComponentResult Invoke()
        {
            var shoppingCartProducts = this.shoppingCartService.GetAllShoppingCartProducts(this.User.Identity.Name);

            var shoppingCartProductsViewModel = shoppingCartProducts.Select(x => new ShoppingCartViewModel
            {
                Id = x.ProductId,
                ImageUrl = x.Product.ImageUrl,
                Name = x.Product.Name,
                Price = x.Product.Price,
                TotalPrice = x.Product.Price,
            }).ToList();

            return this.View(shoppingCartProductsViewModel);
        }
    }
}
