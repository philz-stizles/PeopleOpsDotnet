using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PeopleOps.UI.Pages
{
    [Authorize]
    public class DashboardModel : PageModel
    {
        public IActionResult OnGet()
        {
            /*if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }*/

            return Page();
        }
    }
}
