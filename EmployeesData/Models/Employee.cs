namespace EmployeesData.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public int Salary { set; get; }
    }
}
