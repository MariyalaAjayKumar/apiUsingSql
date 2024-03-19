using EmployeesData.Models;
using EmployeesData.Repository;

namespace EmployeesData.Services
{
        public class EmployeeServices : IEmployeeServices
        {
            private readonly IEmployeeRepository _employeeRepository;
            public EmployeeServices(IEmployeeRepository employeeRepository)
            {
                _employeeRepository = employeeRepository;
            }

            public async Task<Employee> AddEmployee(Employee employee)
            {
                var result =await _employeeRepository.PostMethod(employee);
            return result;
            }

            public async Task DeleteEmployee(int id)
            {
                await _employeeRepository.DeleteMethod(id);
            }

            public async Task<Employee> GetEmployee(int id)
            {
                var result= await _employeeRepository.GetId(id);
                return result;
            }

            public async Task<IEnumerable<Employee>> GetEmployees()
            {
                var result= await _employeeRepository.GetAll();
                return result;
            }

            public async Task<Employee> UpdateEmployee(int id, Employee employee)
            {
                var result =await _employeeRepository.UpdateMethod(id, employee);
                return result;
            }
        }
    }

