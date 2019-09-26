using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SvetulkaApp.Data.Models;
using SvetulkaApp.Web.Services.Interfaces;
using SvetulkaApp.Web.ViewModels.Favorites;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace SvetulkaApp.Web.Controllers
{
    [Authorize]
    public class FavoritesController : BaseController
    {
        private readonly IFavoritesService favoritesService;
        private readonly IMapper mapper;

        public FavoritesController(IFavoritesService favoritesService, IMapper mapper)
        {
            this.favoritesService = favoritesService;
            this.mapper = mapper;
        }

        public IActionResult All()
        {
            IEnumerable<FavoriteProduct> xeonUserFavoriteProducts = this.favoritesService.All(this.User.Identity.Name);

            var favoriteProductsViewModel = this.mapper.Map<IList<AllFavoriteViewModel>>(xeonUserFavoriteProducts);

            return this.View(favoriteProductsViewModel);
        }

        public IActionResult Add(int id)
        {
            this.favoritesService.Add(id, this.User.Identity.Name);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Delete(int id)
        {
            this.favoritesService.Delete(id, this.User.Identity.Name);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
