using System.ComponentModel.DataAnnotations;

namespace ExamCRUD.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public int age { get; set; }   

        public string email { get; set; }
    }
}
