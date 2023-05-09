using API_Entry.Infrastructure.Context;
using API_Entry.Infrastructure.Repositories.Interfaces;
using API_Entry.Models.Abstract;
using Microsoft.EntityFrameworkCore;

namespace API_Entry.Infrastructure.Repositories.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.Status = Status.Passive;
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().Where(x => x.Status != Status.Passive).ToListAsync();
        }

        public Task<T> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task UpdateAsync(T entity)
        {
            entity.UpdatedDate = DateTime.Now;
            entity.Status = Status.Modified;
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

    }
    
   
}
