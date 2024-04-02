using Microsoft.AspNetCore.Mvc;
using VendingMachine.Business.DTOs;
using VendingMachine.Business.Services;
using VendingMachine.Business.Exceptions;

namespace VendingMachine.Api.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<int> CreateProduct([FromBody] ProductDTO productDTO)
        {
            return Ok(_productService.CreateProduct(productDTO));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<ProductDTO>> GetProducts()
        {
            return Ok(_productService.GetProducts());
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<ProductDTO> GetProductById(int id)
        {
            try
            {
                ProductDTO productDTO = _productService.GetProduct(id);
                return Ok(productDTO);
            }
            catch(IdException ex)
            {
                var errorResponse = new
                {
                    errors = new Dictionary<string, List<string>>
                    {
                        { "Id", new List<string> { ex.Message } }
                    }
                };
                return BadRequest(errorResponse);
            }
        }


        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult UpdateProduct(int id, [FromBody] ProductDTO productDTO)
        {
            try
            {
                _productService.UpdateProduct(id, productDTO);
                return NoContent();
            }
            catch(IdException ex)
            {
                var errorResponse = new
                {
                    errors = new Dictionary<string, List<string>>
                    {
                        { "Id", new List<string> { ex.Message } }
                    }
                };
                return BadRequest(errorResponse);
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _productService.DeleteProduct(id);
                return NoContent();
            }
            catch (IdException ex)
            {
                var errorResponse = new
                {
                    errors = new Dictionary<string, List<string>>
                    {
                        { "Id", new List<string> { ex.Message } }
                    }
                };
                return BadRequest(errorResponse);
            }
        }
    }
}
