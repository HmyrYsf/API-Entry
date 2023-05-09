using API_Entry.Infrastructure.Repositories.Interfaces;
using API_Entry.Models.Concrete;
using API_Entry.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace API_Entry.Infrastructure.Repositories.Concrete
{
    public class ProductRepository:BaseRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) : base(context) 
        { 
            _context = context;
        }

        public async Task<List<Product>> GetProductsByCategoryId(int categoryId)
        {
            return await _context.Products.Where(x=>x.Status != Models.Abstract.Status.Passive && x.CategoryId == categoryId).ToListAsync();
        }
    }
}
