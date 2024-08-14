using Kriegspieltech.Domain;
using Kriegspieltech.Domain.Repositories;
using Kriegspieltech.Infrastructure.Persistence.Contexts;

namespace Kriegspieltech.Infrastructure.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly List<T> _dbSet;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public List<T> Table => _dbSet;

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T? GetById(int entityId)
        {
            var query = from entity in _dbSet
                        where
                            entity.Id == entityId
                        select entity;
            return query.FirstOrDefault();
        }

        public void Insert(T entity)
        {
            entity.Id = (from e in _dbSet
                         select e.Id).Max() + 1;
            _dbSet.Add(entity);
        }
    }
}
