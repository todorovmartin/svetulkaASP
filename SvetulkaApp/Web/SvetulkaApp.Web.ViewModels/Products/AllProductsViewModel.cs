using SvetulkaApp.Data.Models.Enums;

namespace SvetulkaApp.Web.ViewModels.Products
{
    public class AllProductsViewModel
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }

        public ProductCategory Category { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string SearchQuery { get; set; }
    }
}
