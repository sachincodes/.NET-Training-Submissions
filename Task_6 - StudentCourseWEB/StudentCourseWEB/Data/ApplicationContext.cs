using Microsoft.EntityFrameworkCore;
using StudentCourseWEB.Models;

namespace StudentCourseWEB.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
            Students = Set<StudentModel>();
            Courses = Set<CourseModel>();
        }
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<CourseModel> Courses { get; set; }
    }
}
