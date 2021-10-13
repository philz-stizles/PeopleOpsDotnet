using AutoMapper;
using PeopleOps.Application.Contracts.Repositories;
using PeopleOps.Application.Contracts.Services;
using PeopleOps.Application.Models;
using PeopleOps.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleOps.Infrastructure.Persistence.Repositories
{
    public class CashAdvanceService : ICashAdvanceService
    {
        private readonly IUserAccessor _userAccessor;
        private readonly ICashAdvanceRepository _cashAdvanceRepository;
        private readonly IMapper _mapper;
        public CashAdvanceService(IUserAccessor userAccessor, 
            ICashAdvanceRepository cashAdvanceRepository, IMapper mapper)
        {
            _userAccessor = userAccessor;
            _cashAdvanceRepository = cashAdvanceRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<CashAdvanceVM>> GetAllAsync()
        {
            var cashAdvances = await _cashAdvanceRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyList<CashAdvanceVM>>(cashAdvances);
        }

        public async Task<CashAdvanceVM> AddAsync(CashAdvanceCreateVM vm)
        {
            var newCashAdvance = _mapper.Map<CashAdvance>(vm);
            newCashAdvance.EmployeeId = _userAccessor.GetCurrentUserId();
            var cashAdvance = await _cashAdvanceRepository.AddAsync(newCashAdvance);
            return _mapper.Map<CashAdvanceVM>(cashAdvance);
        }
    }
}
