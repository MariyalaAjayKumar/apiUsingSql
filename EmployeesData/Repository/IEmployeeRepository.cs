using EmployeesData.Models;

namespace EmployeesData.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetId(int id);
        Task<Employee> PostMethod(Employee employee);
        Task<Employee> UpdateMethod(int id, Employee employee);
        Task DeleteMethod(int id);
    }
}
