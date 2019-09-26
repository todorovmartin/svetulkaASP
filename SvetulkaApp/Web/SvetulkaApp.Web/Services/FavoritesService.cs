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
    public class FavoritesService : IFavoritesService
    {
        private readonly SvetulkaDbContext db;

        public FavoritesService(SvetulkaDbContext db)
        {
            this.db = db;
        }

        public bool Add(int id, string username)
        {
            var user = this.db.Users.Include(x => x.Favorites).FirstOrDefault(x => x.UserName == username);
            if (user == null || user.Favorites.Any(x => x.ProductId == id))
            {
                return false;
            }

            var productExists = this.db.Products.Any(x => x.Id == id);
            if (!productExists)
            {
                return false;
            }

            var favoritesProduct = new FavoriteProduct
            {
                ProductId = id,
                UserId = user.Id,
            };

            user.Favorites.Add(favoritesProduct);
            this.db.SaveChanges();

            return true;
        }

        public IEnumerable<FavoriteProduct> All(string username)
        {
            var userFavorites = this.db.FavoriteProducts.Include(x => x.Product).Where(x => x.User.UserName == username);

            if (userFavorites == null)
            {
                return new List<FavoriteProduct>();
            }

            return userFavorites;
        }

        public void Delete(int id, string username)
        {
            var favoriteProduct = this.db.FavoriteProducts.FirstOrDefault(x => x.User.UserName == username && x.ProductId == id);

            if (favoriteProduct == null)
            {
                return;
            }

            this.db.FavoriteProducts.Remove(favoriteProduct);
            this.db.SaveChanges();
        }
    }
}
