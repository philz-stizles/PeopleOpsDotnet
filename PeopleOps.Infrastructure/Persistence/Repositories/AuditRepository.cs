using PeopleOps.Application.Contracts.Repositories;
using PeopleOps.Domain.Entities;
using System.Threading.Tasks;

namespace PeopleOps.Infrastructure.Persistence.Repositories
{
    public class AuditRepository : IAuditRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public AuditRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Audit> AddAsync(Audit entity)
        {
            _dbContext.Audit.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
