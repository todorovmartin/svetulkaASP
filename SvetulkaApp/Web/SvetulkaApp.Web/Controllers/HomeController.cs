namespace SvetulkaApp.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using SvetulkaApp.Common;
    using SvetulkaApp.Web.Services.Interfaces;
    using SvetulkaApp.Web.ViewModels.Home;
    using System.Collections.Generic;
    using System.Linq;

    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => this.View();
    }
}
