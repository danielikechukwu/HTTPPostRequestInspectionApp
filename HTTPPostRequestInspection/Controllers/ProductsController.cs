using HTTPPostRequestInspection.Models;
using HTTPPostRequestInspection.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HTTPPostRequestInspection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepository _productRepository;

        public ProductsController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // Post method for adding a new product
        // POST api/product
        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Add the product to your data store.
            int ProductId = await _productRepository.AddProduct(product);

            product.Id = ProductId;

            // Return a 201 Created response with the created resource
            return CreatedAtAction("GetProduct", new { Id = product.Id }, product);

        }

        // GET method for retrieving a product by ID
        // GET api/product/1
        [HttpGet("{Id}")]
        public async Task<ActionResult<Product>> GetProduct([FromRoute] int Id)
        {
            // Retrieve and return the product from your data store
            var product = await _productRepository.GetById(Id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}
