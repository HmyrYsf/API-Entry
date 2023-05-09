using API_Entry.Infrastructure.Respositories.Concretes;
using API_Entry.Models.Concrete;

namespace API_Entry.Infrastructure.Respositories.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<bool> AnyCategoryName(string name);
    }
}
