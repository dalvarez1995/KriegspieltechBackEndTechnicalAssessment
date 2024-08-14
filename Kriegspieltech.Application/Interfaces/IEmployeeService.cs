using Domain.Entities;

namespace Kriegspieltech.Application.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetByFullName(string fullname);
        Employee? GetById(int employeeId);

        void AddEmployee(Employee employee);

        void RemoveEmployee(Employee employee);
    }
}
