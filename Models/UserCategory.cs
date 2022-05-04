using System.ComponentModel.DataAnnotations;

namespace ExamCRUD.Models
{
    public class UserCategory
    {
        [Key]
        public Guid id { get; set; }
        
        [Required]
        public string categoryName { get; set; }
    }
}
