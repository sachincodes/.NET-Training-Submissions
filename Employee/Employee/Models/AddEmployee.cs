namespace Employee.Models
{
    public class AddEmployee
    {
        public string? EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Salary { get; set; }
        public string? JoiningDate { get; set; }
        public string? Designation { get; set; }
        public AddEmployee()
        {
            EmployeeId = Guid.NewGuid().ToString();
            /* JoiningDate = DateTime.Now.ToShortDateString();*/
        }
    }

}
