
using EmployeesData.Data;
using EmployeesData.Models;
using EmployeesData.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeData.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeedbContext _employeeDBContext;
        public EmployeeRepository(EmployeedbContext employeeDBContext)
        {
            this._employeeDBContext = employeeDBContext;

        }
        public async Task<IEnumerable<Employee>> GetAll()
        {

            return await _employeeDBContext.Employees.ToListAsync();

        }

        public async Task<Employee> GetId(int id)
        {
            var item = await _employeeDBContext.Employees.FirstOrDefaultAsync(e => e.ID == id);
            return item;
        }

        public async Task<Employee> PostMethod([FromBody] Employee employee)
        {
            var result= await _employeeDBContext.Employees.AddAsync(employee);
            await _employeeDBContext.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<Employee> UpdateMethod(int id, Employee employee)
        {
            var item = await _employeeDBContext.Employees.FirstOrDefaultAsync(e => e.ID == id);
            if (item != null)
            {
                item.FirstName = employee.FirstName;
                item.LastName = employee.LastName;
                item.Gender = employee.Gender;
                item.Salary = employee.Salary;
                await _employeeDBContext.SaveChangesAsync();
                return item;

            }
            return null;


        }

        public async Task DeleteMethod(int id)
        {
            var item = await _employeeDBContext.Employees.FirstOrDefaultAsync(e => e.ID == id);
            if (item != null)
            {
                _employeeDBContext.Employees.Remove(item);
                await _employeeDBContext.SaveChangesAsync();
            }
        }
    }
}
