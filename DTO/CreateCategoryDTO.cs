using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace API_Entry.DTO
{
    public class CreateCategoryDTO
    {
        [Required]
        public string Name { get; set; }
       
    }
}
