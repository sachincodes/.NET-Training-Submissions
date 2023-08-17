using Microsoft.EntityFrameworkCore;
using Repository.Student;
using Repository.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext() : base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SADIQA_SADAF\\MSSQLSERVER03;Initial Catalog=Sadiqa;Integrated Security=True;TrustServerCertificate=True");
        }
        public DbSet<Students> students { get; set; }
        public DbSet<Courses> courses { get; set; }
    }
}
