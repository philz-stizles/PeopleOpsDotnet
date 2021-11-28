using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeopleOps.Application.Contracts.Services;
using PeopleOps.Application.Models;

namespace PeopleOps.UI.Pages.Admin.LeaveRequests
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILeaveRequestService _leaveTypesService;
        public IEnumerable<LeaveRequestVM> LeaveRequests { get; set; }

        public IndexModel(ILeaveRequestService leaveTypesService)
        {
            _leaveTypesService = leaveTypesService;
        }

        public async Task OnGetAsync()
        {
            LeaveRequests = await _leaveTypesService.FindAllAsync(includes: new List<string> { "RequestingEmployee" });
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            try
            {
                await _leaveTypesService.DeleteAsync(id);
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {

                return Page();
            }
        }
    }
}

