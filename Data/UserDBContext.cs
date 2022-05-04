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

        public DbSet<UserCategory> UserCategories { get; set; }

        public DbSet<UserSubCategory> UserSubCategories { get; set; }

        public DbSet<MultiLevelUser> MultiLevelUsers { get; set; }
    }
}
