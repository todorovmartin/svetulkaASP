using SvetulkaApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SvetulkaApp.Web.Services.Interfaces
{
    public interface IShoppingCartService
    {
        void AddProductInCart(int productId, string username);

        bool AnyProducts(string username);

        void DeleteAllProductsFromShoppingCart(string username);

        void DeleteProductFromShoppingCart(int id, string username);

        IEnumerable<ShoppingCartProduct> GetAllShoppingCartProducts(string username);
    }
}
