using Microsoft.EntityFrameworkCore;
using VireshSirTask.Models;
namespace VireshSirTask
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
    public DbSet<Course> Courses { get; set; }
     public DbSet<Student>Students { get; set; }    

    }
}
