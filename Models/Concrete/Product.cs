using API_Entry.Models.Abstract;

namespace API_Entry.Models.Concrete
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
