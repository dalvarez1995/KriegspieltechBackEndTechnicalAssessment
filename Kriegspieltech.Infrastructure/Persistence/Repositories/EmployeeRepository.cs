using Domain.Entities;
using Kriegspieltech.Domain.Repositories;
using Kriegspieltech.Infrastructure.Persistence.Contexts;

namespace Kriegspieltech.Infrastructure.Persistence.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Employee> Table => _dbContext.Employees;

        public List<Employee> GetByFullName(string fullname)
        {
            var query = from employee in _dbContext.Employees
                        where
                            employee.FullName.ToLower().Contains(fullname.ToLower())
                        select employee;

            return query.ToList();
        }


    }
}
