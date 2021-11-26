using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeopleOps.Application.Contracts.Services;
using PeopleOps.Application.Models;

namespace PeopleOps.UI.Pages.Admin.LeaveTypes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILeaveTypeService _leaveTypesService;
        public IEnumerable<LeaveTypeVM> LeaveTypes { get; set; }

        public IndexModel(ILeaveTypeService leaveTypesService)
        {
            _leaveTypesService = leaveTypesService;
        }

        public async Task OnGet()
        {
            LeaveTypes = await _leaveTypesService.GetAllAsync();
        }
    }
}
