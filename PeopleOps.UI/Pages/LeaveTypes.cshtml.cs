using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PeopleOps.Application.Contracts.Services;
using PeopleOps.Application.Models;

namespace PeopleOps.UI.Pages
{
    public class LeaveTypesModel : PageModel
    {
        private readonly ILogger<LeaveTypesModel> _logger;
        private readonly ILeaveTypeService _leaveTypeService;

        public LeaveTypesModel(ILogger<LeaveTypesModel> logger,
            ILeaveTypeService leaveTypeService) 
        {
            _leaveTypeService = leaveTypeService;
        }

        public IEnumerable<LeaveTypeVM> LeaveTypes { get; set; }

        public async Task OnGetAsync()
        {
            LeaveTypes = await _leaveTypeService.GetAllAsync();
        }
    }
}
