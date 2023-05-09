using System.ComponentModel.DataAnnotations;

namespace API_Entry.Models.DTO_s
{
    public class UpdateCategoryDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
