using Model.Student;
using Repository.DataContext;
using Repository.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Student
{
  public  class StudentService: IStudentService
    {
        private StudentContext repo;
        public StudentService()
        {
            repo = new StudentContext();
        }
        public List<StudentModel> GetAllStudent()
        {
            try
            {
                List<StudentModel> studentList = new List<StudentModel>();
                var studentData = repo.Students.ToList();
                var course = repo.Course.ToList();
                foreach (var c in studentData)
                {
                    var student = new StudentModel();
                    student.StudentId = c.StudentId;
                    student.StudentName = c.StudentName;
                    student.CourseId = c.CourseId;
                    studentList.Add(student);
                }
                return studentList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddStudent(StudentModel model)
        {
            try
            {
                var tblStudent = new TblStudent();
                tblStudent.CourseId = model.CourseId;
                tblStudent.StudentName = model.StudentName;
                repo.Students.Add(tblStudent);
                var result = repo.SaveChanges();
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
