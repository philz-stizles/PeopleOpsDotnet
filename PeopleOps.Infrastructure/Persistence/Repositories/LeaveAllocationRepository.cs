using PeopleOps.Application.Contracts.Repositories;
using PeopleOps.Domain.Entities;
using System.Threading.Tasks;

namespace PeopleOps.Infrastructure.Persistence.Repositories
{
    public class LeaveAllocationRepository : RepositoryBase<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> UserHasLeaveForPeriodAsync(int leaveTypeId, string employeeId)
        {
            throw new System.NotImplementedException();
        }
    }
}
