using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Common.Interfaces
{
    public interface IDbRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(Guid id);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        IQueryable<TEntity> GetAll();

        Task<bool> Contains(Expression<Func<TEntity, bool>> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IQueryable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IQueryable<TEntity> entities);
    }
}
