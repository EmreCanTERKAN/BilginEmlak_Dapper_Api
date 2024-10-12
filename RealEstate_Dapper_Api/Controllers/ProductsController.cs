using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
           _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productRepository.GetAllProductAsync();
            return Ok(values);
        }
        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _productRepository.GetAllProductWithCategoryAsync();
            return Ok(values);
        }
        [HttpGet("ProductDealOfTheDayStatusChangeToTrue/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToTrue(int id)
        {
             _productRepository.ProductDealOfTheDayStatusChangeToTrue(id);
            return Ok("İlan Günün fırsatları arasına eklendi");
        }
        [HttpGet("ProductDealOfTheDayStatusChangeToFalse/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            _productRepository.ProductDealOfTheDayStatusChangeToFalse(id);
            return Ok("İlan Günün fırsatları arasından çıkarıldı.");
        }

        [HttpGet("Last5ProductList")]
        public async Task<IActionResult> GetLast5ProductAsync()
        {
            var values = await _productRepository.GetLast5ProductAsync();
            return Ok(values);
        }

        [HttpGet("ProductAdvertListByEmployeeId")]
        public async Task<IActionResult> ProductAdvertsListByEmployee(int id)
        {
            var values = await _productRepository.GetProductAdvertListByEmployeeAsync(id);
            return Ok(values);
        }





    }
} 
