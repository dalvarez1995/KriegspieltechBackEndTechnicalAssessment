using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kriegspieltech.Domain.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        public T? GetById(int entityId);
        public void Insert(T entity);
        public void Delete(T entity);

        public List<T> Table { get; }
    }
}
