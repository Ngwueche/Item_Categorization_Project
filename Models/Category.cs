using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display order")]
        [Range(0, 100, ErrorMessage = "Value out of expected range")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Today;
    }
}
