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
    public class ProductsService : IProductsService
    {
        private readonly SvetulkaDbContext db;

        public ProductsService(SvetulkaDbContext db)
        {
            this.db = db;
        }

        public void AddProduct(Product product)
        {
            if (product == null)
            {
                return;
            }

            this.db.Products.Add(product);
            this.db.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return this.db.Products.ToList();

            //return this.db.Products.Include(x => x.Category)
            //                  .Include(x => x.ImageUrl)
            //                  .Include(x => x.Name)
            //                  .ToList();
        }

        public Product GetProductById(int id)
        {
            return this.db.Products.Include(p => p.Category)
                                   .Include(x => x.ImageUrl)
                                   .Include(x => x.Name)
                                   .Include(x => x.Price)
                                   .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return this.db.Products.Where(x => (int)x.Category == categoryId)
                                   .Include(x => x.ImageUrl)
                                   .Include(x => x.Name)
                                   .Include(x => x.Price);
        }

        public IEnumerable<Product> GetProductsBySearch(string searchString)
        {
            var searchStringClean = searchString.Split(new string[] { ",", ".", " " }, StringSplitOptions.RemoveEmptyEntries);

            IQueryable<Product> products = this.db.Products.Include(x => x.Category)
                                                           .Include(x => x.ImageUrl)
                                                           .Include(x => x.Name)
                                                           .Include(x => x.Price)
                                                           .Where(x => searchStringClean.All(c => x.Name.ToLower().Contains(c.ToLower())));
            return products;
        }
    }
}
