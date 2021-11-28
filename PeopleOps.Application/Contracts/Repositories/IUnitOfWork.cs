using PeopleOps.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace PeopleOps.Application.Contracts.Repositories
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<Employee> Employees { get; }
        IGenericRepository<Message> Messages { get; }
        IGenericRepository<Ticket> Tickets { get; }
        IGenericRepository<Project> Projects { get; }
        IGenericRepository<Job> Jobs { get; }
        IGenericRepository<Role> Roles { get; }
        IGenericRepository<LeaveType> LeaveTypes { get; }
        IGenericRepository<LeaveAllocation> LeaveAllocations { get; }
        IGenericRepository<LeaveRequest> LeaveRequests { get; }
        IGenericRepository<Notification> Notifications { get; }
        IGenericRepository<CashAdvance> CashAdvances { get; }
        Task SaveAsync();
    }
}
