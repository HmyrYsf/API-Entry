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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepo.GetAllAsync();
            if (categories.Count > 0)
            {
                //İşlem başarılı mesajı
                return Ok(categories);
            }
            //Bulunamadı mesajı
            return NotFound("Burada henüz bir kategori yok!!");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id) 
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            if (category != null)
            {
                return Ok(category);
            }
            return NotFound("Böyle bir kategori bulunamadı!!");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                if (await _categoryRepo.AnyCategoryName(model.Name))
                {
                    return BadRequest("Bu kategori zaten var!");
                }
                var category = _mapper.Map<Category>(model);
                await _categoryRepo.AddAsync(category);
                return Ok("Kategori Eklendi!!");
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO model)
        {
            if (ModelState.IsValid) 
            {
                if (await _categoryRepo.AnyCategoryName(model.Name))
                {
                    return BadRequest("Bu ismi kullanamazsınız!!");
                }
                var category = _mapper.Map<Category>(model);
                await _categoryRepo.UpdateAsync(category);
                return Ok("Kategori güncellendi!!");
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            if (category != null)
            {
                await _categoryRepo.DeleteAsync(category);
                return Ok("Kategori silindi!!");
            }
            return NotFound("Böyle bir kategori bulunamadı!!");
        }

    }
}
