using EmployeesData.Models;
using EmployeesData.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeServices _employeeservices;

        public EmployeesController(IEmployeeServices employeeservices)
        {
            _employeeservices = employeeservices;
        }
        [HttpGet]
        public async Task<ActionResult<Employee>> GetAllEmployees()
        {
            try
            {
                return Ok(await _employeeservices.GetEmployees());
            }catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving Data from the database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetByEmployeeId(int id)
        {
            try
            {
                var result = await _employeeservices.GetEmployee(id);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return result;
                }
            }catch(Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error not find Data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            try
            {
                var result = await _employeeservices.AddEmployee(employee);
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error add Data from the database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                if (id != employee.ID)
                {
                    return BadRequest();
                }
                var result = await _employeeservices.UpdateEmployee(id, employee);
                return result;
            }catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error update Data from the database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
               await _employeeservices.DeleteEmployee(id);
                return Ok($"Employee with id:{id} is Deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting Data from the database");
            }
        }
    }
}
