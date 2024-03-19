using EmployeesData.Models;

namespace EmployeesData.Services
{
    public interface IEmployeeServices
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(int id, Employee employee);
        Task DeleteEmployee(int id);
    }
}
