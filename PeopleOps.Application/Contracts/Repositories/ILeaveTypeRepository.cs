using PeopleOps.Domain.Entities;
using System.Collections.Generic;

namespace PeopleOps.Application.Contracts.Repositories
{
    public interface ILeaveTypeRepository: IAsyncRepository<LeaveType>
    {
        ICollection<LeaveType> GetEmployeesByLeaveType(int id);
    }
}
