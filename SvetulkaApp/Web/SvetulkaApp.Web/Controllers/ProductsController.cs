using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SvetulkaApp.Data.Models;
using SvetulkaApp.Web.Services.Interfaces;
using SvetulkaApp.Web.ViewModels.Products;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace SvetulkaApp.Web.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductsService productsService;
        private readonly IMapper mapper;

        public ProductsController(IProductsService productsService, IMapper mapper)
        {
            this.productsService = productsService;
            this.mapper = mapper;
        }

        public Product GetCurrentProduct(int id)
        {
            var product = this.productsService.GetProductById(id);

            return product;
        }

        public IActionResult Details(int id)
        {
            var product = this.productsService.GetProductById(id);

            this.ViewBag.Id = product.Id;
            this.ViewBag.Description = product.Description;
            this.ViewBag.ImageUrl = product.ImageUrl;
            this.ViewBag.Name = product.Name;
            this.ViewBag.Price = product.Price;

            return this.PartialView("_DetailsPartial");
        }

        public IActionResult All(string searchQuery)
        {
            var products = new List<Product>();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                products = this.productsService.GetProductsBySearch(searchQuery).ToList();
            }
            else
            {
                products = this.productsService.GetAllProducts().OrderByDescending(x => x.Id).ToList();
            }

            var allprods = products.ToPagedList();

            var model = allprods.Select(x => new AllProductsViewModel
            {
                Id = x.Id,
                Category = x.Category,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                Price = x.Price,
            });
            return this.View(model);
            // return this.View(allprods);
        }

        public IActionResult Search(string searchQuery)
        {
            return this.RedirectToAction("All", new { searchQuery });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => this.View();
    }
}
