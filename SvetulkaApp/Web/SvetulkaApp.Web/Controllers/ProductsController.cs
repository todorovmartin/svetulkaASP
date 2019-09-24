namespace SvetulkaApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : BaseController
    {
        public ProductsController()
        {

        }

        public IActionResult Details()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        public IActionResult TestPage()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => this.View();
    }
}
