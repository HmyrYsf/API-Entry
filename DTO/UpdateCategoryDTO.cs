using System.ComponentModel.DataAnnotations;

namespace API_Entry.DTO
{
    public class UpdateCategoryDTO
    {
        [Required]
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
