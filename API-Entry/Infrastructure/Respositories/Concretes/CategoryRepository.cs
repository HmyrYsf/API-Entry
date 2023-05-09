using API_Entry.Infrastructure.Context;
using API_Entry.Infrastructure.Respositories.Interfaces;
using API_Entry.Models.Concrete;
using Microsoft.EntityFrameworkCore;

namespace API_Entry.Infrastructure.Respositories.Concretes
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AnyCategoryName(string name)
        {
            return await _context.Categories.Where(x => x.Status != Models.Abstract.Status.Passive).AnyAsync(x => x.Name == name);
        }
    }
}
