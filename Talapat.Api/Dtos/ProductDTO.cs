using Talabat.Core.Entities;

namespace Talapat.Api.Dtos
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
       
    }
}
