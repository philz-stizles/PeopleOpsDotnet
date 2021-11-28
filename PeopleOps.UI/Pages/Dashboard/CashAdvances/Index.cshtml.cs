using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using PeopleOps.Application.Contracts.Services;
using PeopleOps.Application.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleOps.UI.Pages.CashAdvances
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICashAdvanceService _cashAdvanceService;
        private readonly INotyfService _notyf;

        public IndexModel(ILogger<IndexModel> logger,
            ICashAdvanceService cashAdvanceService, INotyfService notyf)
        {
            _cashAdvanceService = cashAdvanceService;
            _notyf = notyf;
        }

        public IEnumerable<CashAdvanceVM> CashAdvances { get; set; }

        [BindProperty]
        public CashAdvanceModel Input { get; set; }

        public class CashAdvancePostModel 
        {
            public CashAdvanceModel Input { get; set; }
        }

        [TempData]
        public string ErrorMessage { get; set; }

        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            await LoadCashAdvances();
        }

        /*public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await _cashAdvanceService.CreateAsync(Input);

                _notyf.Success("Success Notification");

                return RedirectToAction("OnGetAsync");

            }

            await LoadCashAdvances();

            _notyf.Error("Some Error Message");

            return Page();
        }*/

        public PartialViewResult OnGetCashAdvanceModalPartial()
        {
            // this handler returns _CashAdvanceModalPartial
            return new PartialViewResult
            {
                ViewName = "_CashAdvanceModalPartial",
                ViewData = new ViewDataDictionary<CashAdvanceModel>(ViewData, new CashAdvanceModel { })
            };
        }

        private async Task LoadCashAdvances()
        {
            CashAdvances = await _cashAdvanceService.FindAllAsync();
        }
    }
}
