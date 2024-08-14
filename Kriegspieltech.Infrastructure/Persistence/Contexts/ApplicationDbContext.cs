using Domain.Entities;
using Kriegspieltech.Domain;

namespace Kriegspieltech.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext
    {
        private static List<Employee> _employees = new List<Employee>() {
            new(1,"Dominic Alvarez", DateTime.Now),
            new(2,"Fernando Robles", DateTime.Now),
            new(3,"Dom Alvarez", DateTime.Now)
        };

        public List<Employee> Employees { get => _employees; }



        public List<T> Set<T>() where T : IEntity {
            switch (typeof(T))
            {
                default:
                case var type when type is Employee:
                    return Employees as List<T>;
            }
        }
    }
}
