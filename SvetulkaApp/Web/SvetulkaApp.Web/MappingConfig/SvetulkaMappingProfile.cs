using AutoMapper;
using SvetulkaApp.Data.Models;
using SvetulkaApp.Web.Areas.Administration.ViewModels.Products;
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
        }
    }
}
