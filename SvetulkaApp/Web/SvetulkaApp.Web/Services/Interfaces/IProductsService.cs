using SvetulkaApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SvetulkaApp.Web.Services.Interfaces
{
    public interface IProductsService
    {
        Product GetProductById(int id);

        IEnumerable<Product> GetAllProducts();

        IEnumerable<Product> GetProductsByCategory(int categoryId);

        void AddProduct(Product product);

        void DeleteProduct(int id);

        IEnumerable<Product> GetProductsBySearch(string searchString);
    }
}
