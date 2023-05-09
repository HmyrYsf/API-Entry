using System.ComponentModel.DataAnnotations;

namespace API_Entry.Models.DTO_s
{
    public class UpdateProductDTO
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public int Price { get; set; }


        public int CategoryId { get; set; }
    }
}
