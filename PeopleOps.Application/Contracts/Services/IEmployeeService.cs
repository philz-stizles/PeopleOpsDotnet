using PeopleOps.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleOps.Application.Contracts.Services
{
    public interface IEmployeeService
    {
       Task<IReadOnlyList<EmployeeVM>> GetAllAsync();
       Task<EmployeeVM> AddAsync(EmployeeModel model);
    }
}
