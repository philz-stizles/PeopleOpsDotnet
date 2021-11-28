using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PeopleOps.Application.Contracts.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> FindAllAsync(Expression<Func<T, bool>> predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        List<string> includes = null);
        /*Task<IReadOnlyList<T>> FindAllAsync(Expression<Func<T, bool>> predicate = null,
                                       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                       List<Expression<Func<T, object>>> includes = null);*/

        Task<T> FindOneAsync(Expression<Func<T, bool>> predicate, List<string> includes = null);
        /*Task<T> FindOneAsync(Expression<Func<T, bool>> predicate, 
           List<Expression<Func<T, object>>> includes = null);*/

        Task<bool> IsExistsAsync(Expression<Func<T, bool>> predicate);

        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
