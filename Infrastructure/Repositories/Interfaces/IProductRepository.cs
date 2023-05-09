using API_Entry.Models.Concrete;

namespace API_Entry.Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository:IBaseRepository<Product>
    {
        //Kategori Id'sine göre ürün getirme
        Task<List<Product>> GetProductsByCategoryId(int categoryId);
       
    }
}
