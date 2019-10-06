using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SvetulkaApp.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SvetulkaApp.Data.Models;
using SvetulkaApp.Common;
using SvetulkaApp.Web.ViewModels.Favorites;
using SvetulkaApp.Web.ViewModels.ShoppingCart;

namespace SvetulkaApp.Web.Controllers
{
    public class ShoppingCartController : BaseController
    {
        private readonly IShoppingCartService shoppingCartService;
        private readonly IProductsService productSevice;
        private readonly IMapper mapper;

        public ShoppingCartController(IShoppingCartService shoppingCartService, IProductsService productSevice, IMapper mapper)
        {
            this.shoppingCartService = shoppingCartService;
            this.productSevice = productSevice;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var shoppingCartProducts = this.shoppingCartService.GetAllShoppingCartProducts(this.User.Identity.Name);

                if (shoppingCartProducts.Count() == 0)
                {
                    return this.View();
                }

                var shoppingCartProductsViewModel = shoppingCartProducts.Select(x => new ShoppingCartViewModel
                {
                    Id = x.ProductId,
                    ImageUrl = x.Product.ImageUrl,
                    Name = x.Product.Name,
                    Price = x.Product.Price,
                    TotalPrice = x.Product.Price,
                }).ToList();

                // indexViewModel.ShoppingCartProducts = shoppingCartProductsViewModel;
                return this.View(shoppingCartProductsViewModel);
            }

            var cart = SessionHelper.GetObjectFromJson<List<ShoppingCartViewModel>>(this.HttpContext.Session, GlobalConstants.SESSION_SHOPPING_CART_KEY);
            if (cart == null || cart.Count == 0)
            {
                return this.RedirectToAction("Index", "Home");
            }

            return this.View(cart);
        }

        public IActionResult Add(int id)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                this.shoppingCartService.AddProductInCart(id, this.User.Identity.Name);

                return this.RedirectToAction(nameof(this.Index));
            }

            List<ShoppingCartViewModel> cart = SessionHelper.GetObjectFromJson<List<ShoppingCartViewModel>>(this.HttpContext.Session, GlobalConstants.SESSION_SHOPPING_CART_KEY);
            if (cart == null)
            {
                cart = new List<ShoppingCartViewModel>();
            }

            if (!cart.Any(x => x.Id == id))
            {
                var product = this.productSevice.GetProductById(id);

                var shoppingCart = this.mapper.Map<ShoppingCartViewModel>(product);
                shoppingCart.TotalPrice = shoppingCart.Price;

                cart.Add(shoppingCart);

                SessionHelper.SetObjectAsJson(this.HttpContext.Session, GlobalConstants.SESSION_SHOPPING_CART_KEY, cart);
            }

            //if (direct == true)
            //{
            //    return this.RedirectToAction("Create", "Orders", new { defaultDeliveryPrice = true });
            //}

            return this.RedirectToAction(nameof(this.Index));
        }

        public IActionResult Delete(int id)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                this.shoppingCartService.DeleteProductFromShoppingCart(id, this.User.Identity.Name);

                return this.RedirectToAction(nameof(this.Index));
            }

            List<ShoppingCartViewModel> shoppingCartSession = SessionHelper.GetObjectFromJson<List<ShoppingCartViewModel>>(this.HttpContext.Session, GlobalConstants.SESSION_SHOPPING_CART_KEY);
            if (shoppingCartSession == null)
            {
                return this.RedirectToAction(nameof(this.Index));
            }

            if (shoppingCartSession.Any(x => x.Id == id))
            {
                var product = shoppingCartSession.First(x => x.Id == id);
                shoppingCartSession.Remove(product);

                SessionHelper.SetObjectAsJson(this.HttpContext.Session, GlobalConstants.SESSION_SHOPPING_CART_KEY, shoppingCartSession);
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        public IActionResult DeleteAll()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                this.shoppingCartService.DeleteAllProductsFromShoppingCart(this.User.Identity.Name);

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
