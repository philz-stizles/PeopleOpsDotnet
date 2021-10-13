using PeopleOps.Application.Contracts.Repositories;
using PeopleOps.Domain.Entities;

namespace PeopleOps.Infrastructure.Persistence.Repositories
{
    public class CashAdvanceRepository : RepositoryBase<CashAdvance>, ICashAdvanceRepository
    {
        public CashAdvanceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
