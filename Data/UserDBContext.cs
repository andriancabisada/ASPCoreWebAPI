using ExamCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamCRUD.Data
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
