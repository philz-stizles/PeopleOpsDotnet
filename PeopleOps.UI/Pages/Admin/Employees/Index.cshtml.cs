using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeopleOps.Application.Contracts.Services;
using PeopleOps.Application.Models;

namespace PeopleOps.UI.Pages.Admin.Employees
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IEmployeeService _employeeService;
        public IReadOnlyList<EmployeeVM> Employees;

        public IndexModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task OnGetAsync()
        {
            Employees = await  _employeeService.GetAllAsync();
        }
    }
}
