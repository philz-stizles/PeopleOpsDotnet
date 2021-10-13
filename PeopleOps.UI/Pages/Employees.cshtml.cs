using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeopleOps.Application.Models;

namespace PeopleOps.UI.Pages
{
    public class EmployeesModel : PageModel
    {
        public IEnumerable<EmployeeVM> Employees { get; set; }

        public void OnGet()
        {
        }
    }
}
