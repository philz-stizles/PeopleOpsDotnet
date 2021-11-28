using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeopleOps.Application.Contracts.Services;
using PeopleOps.Application.Models;
using System;
using System.Threading.Tasks;

namespace PeopleOps.UI.Pages.Dashboard.Leave
{
    [Authorize]
    public class UpsertModel : PageModel
    {
        private readonly ILeaveRequestService _leaveTypeService;

        [BindProperty]
        public LeaveRequestModel Input { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public UpsertModel(ILeaveRequestService leaveTypeService)
        {
            _leaveTypeService = leaveTypeService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id != null)
            {
                var result = await _leaveTypeService.FindOneAsync((int)id);
                Input = result.Item2;
            }

            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if (Input.Id == 0)
                    {
                        await _leaveTypeService.CreateAsync(Input);
                    }
                    else
                    {
                        await _leaveTypeService.UpdateAsync(Input);
                    }
                    return RedirectToPage("Index");
                }

                return Page();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                return Page();
            }
        }
    }
}
