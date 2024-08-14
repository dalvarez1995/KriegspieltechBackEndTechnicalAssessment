using Domain.Entities;
using Kriegspieltech.Application.Interfaces;
using Kriegspieltech.Domain.Repositories;

namespace Kriegspieltech.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void AddEmployee(Employee employee)
        {
            _employeeRepository.Insert(employee);
        }

        public List<Employee> GetByFullName(string fullname)
        {
            return _employeeRepository.GetByFullName(fullname);
        }

        public Employee? GetById(int employeeId)
        {
            return (_employeeRepository.GetById(employeeId));
        }

        public void RemoveEmployee(Employee employee)
        {
            _employeeRepository.Delete(employee);
        }
    }
}
