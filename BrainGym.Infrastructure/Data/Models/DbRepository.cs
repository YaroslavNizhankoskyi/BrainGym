using AutoMapper;
using AutoMapper.QueryableExtensions;
using BrainGym.Application.Common.Interfaces;
using BrainGym.Infrastructure.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Infrastructure.Data.Models
{
    public class DbRepository<TEntity> : IDbRepository<TEntity> where TEntity : class
    {
        internal DbContext context;
        internal DbSet<TEntity> dbSet;


        public DbRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);

            if(entity == null)
            {
                var typeName = typeof(TEntity).Name;

                throw new NotFoundException($"{typeName} not found");
            }

            return entity;
        }

        public async Task<TEntity> GetByIdOrDefault(Guid id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }


        public IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }

        public async Task<bool> Contains(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.AnyAsync(predicate);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public async void AddRange(IQueryable<TEntity> entities)
        {
            await context.Set<TEntity>().AddRangeAsync(entities);
        }

        public void Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IQueryable<TEntity> entities)
        {
            context.Set<TEntity>().RemoveRange(entities);
        }

        public IQueryable<TResult> ProjectTo<TResult>(IConfigurationProvider provider)
        {
            return GetAll().ProjectTo<TResult>(provider);
        }

    }

}
