using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SvetulkaApp.Data.Models;
using SvetulkaApp.Web.Areas.Administration.ViewModels.Products;
using SvetulkaApp.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace SvetulkaApp.Web.Areas.Administration.Controllers
{
    public class ProductsController : AdministrationController
    {
        private const int DEFAULT_PAGE_SIZE = 8;
        private const int DEFAULT_PAGE_NUMBER = 1;

        private readonly IProductsService productsService;
        private readonly IMapper mapper;

        public ProductsController(IProductsService productService, IMapper mapper)
        {
            this.productsService = productService;
            this.mapper = mapper;
        }

        public IActionResult All(int? pageNumber, int? pageSize)
        {
            var products = this.productsService.GetAllProducts().OrderByDescending(x => x.Id).ToList();

            pageNumber = pageNumber ?? DEFAULT_PAGE_NUMBER;
            pageSize = pageSize ?? DEFAULT_PAGE_SIZE;

            var pageProductsViewModel = products.ToPagedList(pageNumber.Value, pageSize.Value);

            return this.View(pageProductsViewModel);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateProductViewModel model)
        {
            var product = this.mapper.Map<Product>(model);

            this.productsService.AddProduct(product);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Edit(int id)
        {
            var product = this.productsService.GetProductById(id);

            if (product == null)
            {
                return this.NotFound();
            }

            var model = this.mapper.Map<EditProductViewModel>(product);

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProductViewModel model)
        {
            var product = this.mapper.Map<Product>(model);

            this.productsService.EditProduct(product);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Details(int id)
        {
            var product = this.productsService.GetProductById(id);

            if (product == null)
            {
                return this.NotFound();
            }

            var model = this.mapper.Map<DetailsProductViewModel>(product);

            return this.View(model);
        }
    }
}
