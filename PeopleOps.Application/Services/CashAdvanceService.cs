using AutoMapper;
using PeopleOps.Application.Contracts.Repositories;
using PeopleOps.Application.Contracts.Services;
using PeopleOps.Application.Models;
using PeopleOps.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleOps.Infrastructure.Persistence.Repositories
{
    public class CashAdvanceService : ICashAdvanceService
    {
        private readonly IUserAccessor _userAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CashAdvanceService(IUserAccessor userAccessor, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userAccessor = userAccessor;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<CashAdvanceVM>> FindAllAsync()
        {
            var cashAdvances = await _unitOfWork.CashAdvances.FindAllAsync();
            return _mapper.Map<IReadOnlyList<CashAdvanceVM>>(cashAdvances);
        }

        public async Task CreateAsync(CashAdvanceModel model)
        {
            var newCashAdvance = _mapper.Map<CashAdvance>(model);
            newCashAdvance.EmployeeId = _userAccessor.GetCurrentUserId();
            newCashAdvance.CreatedBy = _userAccessor.GetCurrentUserId();
            newCashAdvance.CreatedDate = DateTime.Now;
            await _unitOfWork.CashAdvances.CreateAsync(newCashAdvance);
            await _unitOfWork.SaveAsync();
        }
    }
}
