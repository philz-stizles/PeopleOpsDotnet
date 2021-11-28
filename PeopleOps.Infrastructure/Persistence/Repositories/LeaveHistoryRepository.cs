using PeopleOps.Application.Contracts.Repositories;
using PeopleOps.Domain.Entities;

namespace PeopleOps.Infrastructure.Persistence.Repositories
{
    public class LeaveHistoryRepository : GenericRepository<LeaveHistory>, ILeaveHistoryRepository
    {
        public LeaveHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
