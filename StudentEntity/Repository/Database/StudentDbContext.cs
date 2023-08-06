using Microsoft.EntityFrameworkCore;
using Repository.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Database
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext() : base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-DJ68PL2\\MSSQLSERVER01;Database=Practice;Trusted_Connection=True;Encrypt=false;");
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
