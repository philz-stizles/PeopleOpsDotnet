using PeopleOps.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleOps.Application.Contracts.Services
{
    public interface ICashAdvanceService
    {
        Task<IReadOnlyList<CashAdvanceVM>> FindAllAsync();
        Task CreateAsync(CashAdvanceModel model);
    }
}
