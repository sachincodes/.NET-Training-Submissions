using Repository.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Course;
using Repository.DataModel;

namespace Service.Course
{

   public class CourseService : ICourseService
    {
        private StudentContext repo;
        public CourseService()
        {
            repo = new StudentContext();
        }
        public List<CourseModel> GetAllCourse()
        {
            try
            {
                List<CourseModel> courseList = new List<CourseModel>();
                var courseData = repo.Course.ToList();
                foreach (var c in courseData)
                {
                    var course = new CourseModel();
                    course.CourseId = c.CourseId;
                    course.CourseName = c.CourseName;
                    courseList.Add(course);
                }
                return courseList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddCourse(CourseModel model)
        {
            try
            {
                var course = new TblCourse();
                course.CourseName = model.CourseName;
               repo.Course.Add(course);
                var result=repo.SaveChanges();
                if (result > 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
