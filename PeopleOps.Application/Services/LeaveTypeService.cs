using AutoMapper;
using PeopleOps.Application.Contracts.Repositories;
using PeopleOps.Application.Contracts.Services;
using PeopleOps.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleOps.Infrastructure.Persistence.Repositories
{
    public class LeaveTypeService : ILeaveTypeService
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public LeaveTypeService(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<LeaveTypeVM>> GetAllAsync()
        {
            var leavetypes = await _leaveTypeRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyList<LeaveTypeVM>>(leavetypes);
        }
    }
}
