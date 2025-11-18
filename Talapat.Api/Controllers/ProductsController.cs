using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.IRepositories;
using Talabat.Core.Specifications;
using Talapat.Api.Dtos;
using Talapat.Api.Errors;

namespace Talapat.Api.Controllers
{
    
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepo , IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            var spec = new BaseSpecifications<Product>();
            var products = await _productRepo.GetAllWithSpecAsync(spec);
            var dto = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return Ok(dto);
        }
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var spec = new BaseSpecifications<Product>(p=>p.Id==id);
            var product = await _productRepo.GetByIdWithSpecAsync(spec);
            if (product is null)
                return NotFound(new ApiResponse(404));
            var dto = _mapper.Map<ProductDTO>(product);
            return Ok(dto);
        }
    } 
}
