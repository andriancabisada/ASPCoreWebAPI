using System.ComponentModel.DataAnnotations;

namespace ExamCRUD.Models
{
    public class UserSubCategory
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string categoryNameId { get; set; }

        [Required]
        public string categoryName { get; set; }

        [Required(ErrorMessage ="Sub Category Name Required")]
        public string subCategoryName { get; set; }
    }
}
