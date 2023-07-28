using System.ComponentModel.DataAnnotations.Schema;

namespace VireshSirTask.Models.ViewModel
{
    public class StudentView
    {

 
        public string Course { get; set; }

        public string StudentName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }
}
