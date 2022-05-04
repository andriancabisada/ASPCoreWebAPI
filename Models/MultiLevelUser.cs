using System.ComponentModel.DataAnnotations;

namespace ExamCRUD.Models
{
    public class MultiLevelUser
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public string Department { get; set; }

        public string Category { get; set; }


    }
}
