using PeopleOps.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleOps.Application.Contracts.Services
{
    public interface ILeaveTypeService
    {
        Task<IReadOnlyList<LeaveTypeVM>> GetAllAsync();
    }
}
