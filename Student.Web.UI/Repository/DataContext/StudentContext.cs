using Repository.DataModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DataContext
{
    public class StudentContext : DbContext
    {
        private static string _connectionString;
        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    string _connectionString = ConfigurationManager.AppSettings["dbConnection"];
                }
                return _connectionString;
            }
            set { _connectionString = value; }
        }
        public StudentContext() : base(ConfigurationManager.AppSettings["dbConnection"])
        {

        }
        public DbSet<TblStudent>Students{get;set;}
        public DbSet<TblCourse> Course { get; set; }
    }
}
