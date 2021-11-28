using PeopleOps.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PeopleOps.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _db;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _db = _dbContext.Set<T>();
        }


        public async Task<IReadOnlyList<T>> FindAllAsync(Expression<Func<T, bool>> predicate = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            IQueryable<T> query = _db;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includes != null) 
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            };

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync();
        }

        /*public async Task<IReadOnlyList<T>> FindAllAsync(Expression<Func<T, bool>> predicate = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null)
        {
            IQueryable<T> query = _db;

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync();
        }*/


        public async Task<T> FindOneAsync(Expression<Func<T, bool>> predicate, 
            List<string> includes = null)
        {
            IQueryable<T> query = _db;

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return await query.FirstOrDefaultAsync(predicate);
        }

       /* public async Task<T> FindOneAsync(Expression<Func<T, bool>> predicate, 
            List<Expression<Func<T, object>>> includes = null)
        {
            IQueryable<T> query = _db;
 
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return await query.FirstOrDefaultAsync(predicate);
        }*/

        public async Task<bool> IsExistsAsync(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _db;

            return await query.AnyAsync(predicate);
        }

        public async Task CreateAsync(T entity)
        {
           await  _db.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _db.Update(entity);
        }

        public void Delete(T entity)
        {
            _db.Remove(entity);
        }
    }
}
