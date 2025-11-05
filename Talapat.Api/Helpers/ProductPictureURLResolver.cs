using AutoMapper;
using Talabat.Core.Entities;
using Talapat.Api.Dtos;

namespace Talapat.Api.Helpers
{
    public class ProductPictureURLResolver : IValueResolver<Product, ProductDTO, string>
    {
        private readonly IConfiguration _configuration;

        public ProductPictureURLResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{_configuration["ApiBaseURL"]}/{source.PictureUrl}";
            }
            return string.Empty ;
        }
    }
}
