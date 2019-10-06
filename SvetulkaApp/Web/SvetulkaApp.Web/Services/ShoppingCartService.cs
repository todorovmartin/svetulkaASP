using Microsoft.EntityFrameworkCore;
using SvetulkaApp.Data;
using SvetulkaApp.Data.Models;
using SvetulkaApp.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SvetulkaApp.Web.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly SvetulkaDbContext db;
        private readonly IProductsService productsService;
        private readonly IUsersService userService;

        public ShoppingCartService(SvetulkaDbContext db, IProductsService productsService, IUsersService userService)
        {
            this.db = db;
            this.productsService = productsService;
            this.userService = userService;
        }

        public void AddProductInCart(int productId, string username)
        {
            var product = this.productsService.GetProductById(productId);
            var user = this.userService.GetUserByUsername(username);
            var userShoppingCartId = user.ShoppingCartId;

            if (product == null || user == null)
            {
                return;
            }

            var shoppingCartProduct = this.GetShoppingCartProduct(productId, userShoppingCartId);

            if (shoppingCartProduct != null)
            {
                return;
            }

            shoppingCartProduct = new ShoppingCartProduct
            {
                Product = product,
                ShoppingCartId = userShoppingCartId,
            };

            this.db.ShoppingCartProducts.Add(shoppingCartProduct);
            this.db.SaveChanges();
        }

        public bool AnyProducts(string username)
        {
            return this.db.ShoppingCartProducts.Any(x => x.ShoppingCart.User.UserName == username);
        }

        public void DeleteAllProductsFromShoppingCart(string username)
        {
            var user = this.userService.GetUserByUsername(username);

            if (user == null)
            {
                return;
            }

            var shoppingCartProducts = this.db.ShoppingCartProducts.Where(x => x.ShoppingCartId == user.ShoppingCartId);

            this.db.ShoppingCartProducts.RemoveRange(shoppingCartProducts);
            this.db.SaveChanges();
        }

        public void DeleteProductFromShoppingCart(int id, string username)
        {
            var product = this.productsService.GetProductById(id);
            var user = this.userService.GetUserByUsername(username);

            if (product == null || user == null)
            {
                return;
            }

            var shoppingCart = this.GetShoppingCartProduct(product.Id, user.ShoppingCartId);

            this.db.ShoppingCartProducts.Remove(shoppingCart);
            this.db.SaveChanges();
        }

        public IEnumerable<ShoppingCartProduct> GetAllShoppingCartProducts(string username)
        {
            var user = this.userService.GetUserByUsername(username);

            if (user == null)
            {
                return null;
            }

            // return this.db.ShoppingCartProducts.Where(x => x.ShoppingCart.User.UserName == username).ToList();
            return this.db.ShoppingCartProducts
                .Include(x => x.Product)
                .Include(x => x.ShoppingCart)
                .Where(x => x.ShoppingCart.Id == user.ShoppingCartId).ToList();
        }

        private ShoppingCartProduct GetShoppingCartProduct(int productId, int shoppingCartId)
        {
            return this.db.ShoppingCartProducts.FirstOrDefault(x => x.ShoppingCartId == shoppingCartId && x.ProductId == productId);
        }
    }
}
