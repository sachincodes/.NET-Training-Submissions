using Repository.Database;
using Repository.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly StudentDbContext _dbContext;

        public CourseRepository(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _dbContext.Courses.ToList();
        }
    }
}
