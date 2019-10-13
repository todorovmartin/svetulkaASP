using SvetulkaApp.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SvetulkaApp.Web.Areas.Administration.ViewModels.Products
{
    public class DetailsProductViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Name { get; set; }

        [Display(Name = "Category")]
        public int ProductCategoryId { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }
    }
}
