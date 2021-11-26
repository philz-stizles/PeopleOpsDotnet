using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeopleOps.Application.Contracts.Services;
using PeopleOps.Application.Models;
using System.Threading.Tasks;

namespace PeopleOps.UI.Pages.Admin.Employees
{
    [Authorize]
    public class UpsertModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        [BindProperty]
        public EmployeeModel Input { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public UpsertModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public void OnGet()
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var createdEmployee = await _employeeService.AddAsync(Input);
                return Redirect("/Admin/Employees");
            }

            return Page();
        }
    }
}
