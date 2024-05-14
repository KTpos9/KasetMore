using KasetMore.Data.Models;
using KasetMore.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KasetMore.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                return Ok(_productRepository.GetProducts());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("products/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                return Ok(_productRepository.GetProductById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("update-rpoduct")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            try
            {
                await _productRepository.UpdateProduct(product);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct(Product product)
        {
            try
            {
                await _productRepository.AddProduct(product);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("delete-product")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _productRepository.DeleteProduct(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
