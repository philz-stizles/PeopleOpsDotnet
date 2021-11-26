using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PeopleOps.Application.Contracts.Services;
using PeopleOps.Application.Models;
using PeopleOps.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleOps.Infrastructure.Persistence.Repositories
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUserAccessor _userAccessor;
        private readonly UserManager<Employee> _userManager;
        private readonly IMapper _mapper;
        public EmployeeService(IUserAccessor userAccessor,
            UserManager<Employee> userManager, IMapper mapper)
        {
            _userAccessor = userAccessor;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<EmployeeVM>> GetAllAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return _mapper.Map<IReadOnlyList<EmployeeVM>>(users);
        }

        public async Task<EmployeeVM> AddAsync(EmployeeModel model)
        {
            var newEmployee = _mapper.Map<Employee>(model);

            // Generate random password.

            // Send login credentials to new employee.

            newEmployee.UserName = model.Email;
            var result = await _userManager.CreateAsync(newEmployee, "P@ssw0rd");


            return _mapper.Map<EmployeeVM>(model);
        }
    }
}
