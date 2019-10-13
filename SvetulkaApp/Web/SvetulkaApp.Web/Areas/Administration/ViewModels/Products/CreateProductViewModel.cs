using SvetulkaApp.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SvetulkaApp.Web.Areas.Administration.ViewModels.Products
{
    public class CreateProductViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "\"{0}\" is reqired.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "\"{0}\" should be min {2} and max {1}.")]
        public string Name { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "\"{0}\" is required.")]
        public string Category { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "\"{0}\" is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "\"{0}\" should be between {1} and {2}")]
        public decimal Price { get; set; }

        [Display(Name = "Tags")]
        public string Tags { get; set; }
    }
}
