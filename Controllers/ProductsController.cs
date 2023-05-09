using API_Entry.DTO;
using API_Entry.Infrastructure.Repositories.Interfaces;
using API_Entry.Models.Concrete;
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
            var product = await _productRepo.GetAllAsync();
            if (product.Count > 0)
            {
                return Ok(product);
            }
            return NotFound("Burada henüz bir ürün yok!!");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducts(int id) 
        { 
            var product = await _productRepo.GetProductsByCategoryId(id);
            if (product.Count > 0)
            {
                return Ok(product);
            }
            return NotFound("Bu kategoriye ait ürün bulunmamaktadır!");
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO model)
        {
            if(ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(model);
                await _productRepo.AddAsync(product);
                return Ok("Ürün eklendi");
            }
            return BadRequest("Ürün eklenemedi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO model)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(model);
                await _productRepo.UpdateAsync(product);
                return Ok("Ürün güncellendi!");
            }
            return BadRequest("Ürün güncellenemedi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if(product != null)
            {
                await _productRepo.DeleteAsync(product);
                return Ok("Ürün Silindi");
            }
            return NotFound("ürün bulunamadı.");
        }
    }
}
