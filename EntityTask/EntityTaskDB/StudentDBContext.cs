using Microsoft.EntityFrameworkCore;

namespace EntityTaskDB
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext() : base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ESHUKUMAR;Initial Catalog=CodefirstDatabase;Integrated Security=True");
        }
        public DbSet<Students> students { get; set; }
        public DbSet<Courses> courses { get; set; }

    }
}
