using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kriegspieltech.Domain.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        List<Employee> GetByFullName(string fullname);
    }
}
