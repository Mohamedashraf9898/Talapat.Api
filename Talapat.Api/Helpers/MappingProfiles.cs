using AutoMapper;
using Talabat.Core.Entities;
using Talapat.Api.Dtos;

namespace Talapat.Api.Helpers
{
    public class MappingProfiles : Profile
    {
        

        public MappingProfiles()
        {
            CreateMap<Product, ProductDTO>().AfterMap((src, dest) =>
            {
                dest.BrandName = src.Brand.Name;
                dest.CategoryName = src.Category.Name;
            }).ForMember(p=>p.PictureUrl , o=>o.MapFrom<ProductPictureURLResolver>()) ;
            
        }
    }
}
