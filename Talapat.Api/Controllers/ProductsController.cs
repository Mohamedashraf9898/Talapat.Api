using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.IRepositories;
using Talabat.Core.Specifications;

namespace Talapat.Api.Controllers
{
    
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;

        public ProductsController(IGenericRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var spec = new BaseSpecifications<Product>();
            var products = await _productRepo.GetAllWithSpecAsync(spec);
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var spec = new BaseSpecifications<Product>(p=>p.Id==id);
            var product = await _productRepo.GetByIdWithSpecAsync(spec);
            if (product is null)
                return NotFound(new {Message = "Product is Not Found" , StatusCode = 404});
            return Ok(product);
        }
    } 
}
