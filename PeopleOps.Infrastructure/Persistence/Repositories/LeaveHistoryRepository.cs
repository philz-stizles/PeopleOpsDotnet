using PeopleOps.Application.Contracts.Repositories;
using PeopleOps.Domain.Entities;

namespace PeopleOps.Infrastructure.Persistence.Repositories
{
    public class LeaveHistoryRepository : RepositoryBase<LeaveHistory>, ILeaveHistoryRepository
    {
        public LeaveHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
