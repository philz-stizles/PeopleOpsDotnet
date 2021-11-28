using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeopleOps.Application.Contracts.Services;
using PeopleOps.Application.Models;
using System;
using System.Threading.Tasks;

namespace PeopleOps.UI.Pages.Admin.LeaveTypes
{
    [Authorize]
    public class UpsertModel : PageModel
    {
        private readonly ILeaveTypeService _leaveTypeService;

        [BindProperty]
        public LeaveTypeModel Input { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public UpsertModel(ILeaveTypeService leaveTypeService)
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
