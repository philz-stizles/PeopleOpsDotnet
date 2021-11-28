using PeopleOps.Application.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleOps.Application.Contracts.Services
{
    public interface ILeaveTypeService
    {
        Task<IReadOnlyList<LeaveTypeVM>> GetAllAsync();
        Task<Tuple<LeaveTypeVM, LeaveTypeModel>> FindOneAsync(int id);
        Task CreateAsync(LeaveTypeModel model);
        Task UpdateAsync(LeaveTypeModel model);
        Task DeleteAsync(int id);
    }
}
