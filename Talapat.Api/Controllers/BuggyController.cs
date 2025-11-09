using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talapat.Api.Errors;
using Talapat.Repository.Data;

namespace Talapat.Api.Controllers
{
   
    public class BuggyController : BaseApiController
    {
        private readonly TalabatDbContext _dbContext;

        public BuggyController(TalabatDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("notfound")]
        public ActionResult GetNotFound()
        {
            var product = _dbContext.Products.Find(100);
            if(product is null) return NotFound(new ApiResponse(404));
            return Ok(product);
        }
        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var product = _dbContext.Products.Find(100);
            var productToReturn = product.ToString();
            return Ok(productToReturn);
        }
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("validationerror/{id}")]
        public ActionResult getValidationError(int id)
        {
            return Ok();
        }
    }

}
