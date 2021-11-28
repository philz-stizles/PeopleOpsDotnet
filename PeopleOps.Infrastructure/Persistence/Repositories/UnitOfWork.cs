using PeopleOps.Application.Contracts.Repositories;
using PeopleOps.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace PeopleOps.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private IGenericRepository<Employee> _employees;
        private IGenericRepository<Message> _messages; 
        private IGenericRepository<Ticket> _tickets ;
        private IGenericRepository<Project> _projects ;
        private IGenericRepository<Job> _jobs;
        private IGenericRepository<Role> _roles;
        private IGenericRepository<LeaveType> _leaveTypes;
        private IGenericRepository<LeaveAllocation> _leaveAllocations;
        private IGenericRepository<LeaveRequest> _leaveRequests;
        private IGenericRepository<Notification> _notifications;
        private IGenericRepository<CashAdvance> _cashAdvances;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<Employee> Employees => _employees ??= new GenericRepository<Employee>(_dbContext);
        public IGenericRepository<Message> Messages => _messages ??= new GenericRepository<Message>(_dbContext);
        public IGenericRepository<Ticket> Tickets => _tickets ??= new GenericRepository<Ticket>(_dbContext);
        public IGenericRepository<Project> Projects => _projects ??= new GenericRepository<Project>(_dbContext);
        public IGenericRepository<Job> Jobs => _jobs ??= new GenericRepository<Job>(_dbContext);
        public IGenericRepository<Role> Roles => _roles ??= new GenericRepository<Role>(_dbContext);
        public IGenericRepository<LeaveType> LeaveTypes => _leaveTypes ??= new GenericRepository<LeaveType>(_dbContext);
        public IGenericRepository<LeaveAllocation> LeaveAllocations => _leaveAllocations ??= new GenericRepository<LeaveAllocation>(_dbContext);
        public IGenericRepository<LeaveRequest> LeaveRequests => _leaveRequests ??= new GenericRepository<LeaveRequest>(_dbContext);
        public IGenericRepository<Notification> Notifications => _notifications ??= new GenericRepository<Notification>(_dbContext);
        public IGenericRepository<CashAdvance> CashAdvances => _cashAdvances ??= new GenericRepository<CashAdvance>(_dbContext);


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dispose)
        {
            if (dispose)
            {
                _dbContext.Dispose();
            }
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
