using Repository.Repositoty;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryContext
{
    public class StudentdatabaseContext : DbContext
    {
        private static string _conn;
        public static string ConnectionString
        {
            get
            {
                if(string.IsNullOrEmpty(_conn))
                {
                    _conn = System.Configuration.ConfigurationManager.AppSettings["myConnectionString"];
                }
                return _conn;
            }
            set { _conn = value; }
        }
        public StudentdatabaseContext():base(_conn) { }
        public DbSet<Students> Student { get; set; }
        public DbSet<Course> Course { get; set; }
    }
}
