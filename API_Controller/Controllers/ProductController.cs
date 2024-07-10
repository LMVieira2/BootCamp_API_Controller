using BootCamp_Domain.DTOs;
using BootCamp_Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace API_Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<IEnumerable<Product>> GetTodoItems()
        {
            return await _productRepository.GetAll();
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetTodoItem(Guid id)
        {
            return await _productRepository.GetById(id);
        }

        // PUT: api/TodoItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(Guid id, Product productItem)
        {
            var updatedProduct = await _productRepository.Update(id, productItem);
            return Ok(updatedProduct);
        }

        // POST: api/TodoItems
        [HttpPost]
        public async Task<ProductDTO> PostTodoItem(ProductDTO productItem)
        {
            var product = new Product
            {
                Name = productItem.Name,
                Description = productItem.Description,
                Price = productItem.Price
            };
            return await _productRepository.Add(product);
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(Guid id)
        {
            bool result = await _productRepository.Delete(id);
            if (result)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}