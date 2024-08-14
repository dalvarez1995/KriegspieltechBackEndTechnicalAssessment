using Domain.Entities;
using Kriegspieltech.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet(Name = "GetEmployees")]
        public List<Employee> Get(string fullname)
        {
            return _employeeService.GetByFullName(fullname);
        }

        [HttpPost(Name = "AddEmployee")]
        public IActionResult Post(string fullname, DateTime birth)
        {
            var employee = new Employee(fullname, birth);
            _employeeService.AddEmployee(employee);
            return Ok();
        }

        [HttpDelete("{id}/Delete")]
        public IActionResult Delete(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
                return NotFound();
            _employeeService.RemoveEmployee(employee);
            return Ok();
        }
    }
}
