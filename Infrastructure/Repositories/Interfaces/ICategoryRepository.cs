using API_Entry.Infrastructure.Repositories.Concrete;
using API_Entry.Models.Concrete;

namespace API_Entry.Infrastructure.Repositories.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<bool> AnyCategoryName(string name);
       
    }
}
