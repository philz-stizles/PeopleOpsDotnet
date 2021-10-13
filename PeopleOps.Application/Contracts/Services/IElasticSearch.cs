using PeopleOps.Domain.Entities;
using System.Threading.Tasks;

namespace PeopleOps.Application.Contracts.Services
{
    public interface IElasticSearch<T> where T : EntityBase
    {
        Task Index();

        Task IndexAsync();

        Task IndexAsync(T entity, int from, int size);
    }
}
