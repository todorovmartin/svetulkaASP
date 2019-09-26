using AutoMapper;
using SvetulkaApp.Data.Models;
using SvetulkaApp.Web.Areas.Administration.ViewModels.Products;
using SvetulkaApp.Web.ViewModels.Favorites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SvetulkaApp.Web.MappingConfig
{
    public class SvetulkaMappingProfile : Profile
    {
        public SvetulkaMappingProfile()
        {
            this.CreateMap<CreateProductViewModel, Product>();
            this.CreateMap<EditProductViewModel, Product>();
            this.CreateMap<Product, EditProductViewModel>();

            this.CreateMap<FavoriteProduct, AllFavoriteViewModel>()
                .ForMember(x => x.ProductImageUrl, y => y.MapFrom(src => src.Product.ImageUrl));
        }
    }
}
