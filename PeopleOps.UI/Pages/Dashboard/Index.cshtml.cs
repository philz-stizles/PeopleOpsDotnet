using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PeopleOps.UI.Pages.Dashboard
{
    [Authorize]
    public class IndexModel : PageModel
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
