using Microsoft.Build.Framework;

namespace API_Entry.Models.DTO_s
{
    public class CreateCategoryDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
