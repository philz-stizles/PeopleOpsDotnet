using PeopleOps.Application.Models;
using PeopleOps.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PeopleOps.Application.Contracts.Services
{
    public interface ILeaveRequestService
    {
        Task<IReadOnlyList<LeaveRequestVM>> FindAllAsync(Expression<Func<LeaveRequest, bool>> predicate = null,
                                        Func<IQueryable<LeaveRequest>, IOrderedQueryable<LeaveRequest>> orderBy = null,
                                        List<string> includes = null);
        Task<Tuple<LeaveRequestVM, LeaveRequestModel>> FindOneAsync(int id);
        Task CreateAsync(LeaveRequestModel model);
        Task UpdateAsync(LeaveRequestModel model);
        Task DeleteAsync(int id);
    }
}
