using PeopleOps.Domain.Entities;
using System.Threading.Tasks;

namespace PeopleOps.Application.Contracts.Repositories
{
    public interface ILeaveAllocationRepository: IAsyncRepository<LeaveAllocation>
    {
        Task<bool> UserHasLeaveForPeriodAsync(int leaveTypeId, string employeeId);
    }
}
