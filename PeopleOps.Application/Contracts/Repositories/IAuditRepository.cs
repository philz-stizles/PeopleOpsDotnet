using PeopleOps.Domain.Entities;
using System.Threading.Tasks;

namespace PeopleOps.Application.Contracts.Repositories
{
    public interface IAuditRepository
    {
        Task<Audit> AddAsync(Audit entity);
    }
}
