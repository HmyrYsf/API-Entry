using API_Entry.Infrastructure.Respositories.Interfaces;
using API_Entry.Models.Concrete;
using API_Entry.Models.DTO_s;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Entry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts() 
        {
            var products = await _productRepo.GetAllAsync();
            if (products.Count > 0)
            {
                return Ok(products);
            }
            return NotFound("Ürün bulunamadı!!!");
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducts(int id)
        {
            var products = await _productRepo.GetProductsByCategoryId(id);
            if (products.Count > 0)
            {
                return Ok(products);
            }
            return NotFound("Bu kategoriye ait ürün bulunmamaktadır!!");
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO model)
        {
            if (ModelState.IsValid) 
            {
                var product = _mapper.Map<Product>(model);
                await _productRepo.AddAsync(product);
                return Ok("Ürün eklendi!!");
            }
            return BadRequest("Ürün eklenemedi!!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO model)
        {
            if (ModelState.IsValid) 
            {
                var product = _mapper.Map<Product>(model);
                await _productRepo.UpdateAsync(product);
                return Ok("Ürün güncellendi!!");
            }
            return BadRequest("ürün güncellenemedi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product != null)
            {
                await _productRepo.DeleteAsync(product);
                return Ok("Ürün silindi!!");
            }
            return NotFound("Ürün bulunamadı!!!");
        }
    }
}
