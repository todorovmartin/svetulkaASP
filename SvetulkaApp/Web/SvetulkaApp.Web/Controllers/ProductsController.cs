using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SvetulkaApp.Data.Models;
using SvetulkaApp.Web.Services.Interfaces;
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

        //    public IActionResult Details() =>
        //new PartialViewResult
        //{
        //    ViewName = "_DetailsPartial",
        //    ViewData = this.ViewData,
        //};

        public IActionResult All()
        {
            var products = this.productsService.GetAllProducts().OrderByDescending(x => x.Id).ToList();

            var allprods = products.ToPagedList();

            return this.View(allprods);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => this.View();
    }
}
