using AutoMapper;
using Model;
using Repository.DbModel;
using StudentEntity.Model;

namespace Service
{
    public class AutoMapperFile : Profile
    {
        public AutoMapperFile()
        {
            // Configure mapping from Course to CourseModel
            CreateMap<Course, CourseModel>();

            // Configure mapping from Student to StudentViewModel
            CreateMap<Student, StudentModel>();
        }
    }
}
