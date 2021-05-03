using Notifier.Data;
using Notifier.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Notifier.Pages.Rules.Misc
{
    public class IndexModel : CI_BasePageModel
    {
        public IndexModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        public IList<MiscRule> MiscRule { get; set; }
        public string toRedirect { get; set; }

        public IActionResult OnGet()
        {
            var currentUserId = UserManager.GetUserId(User);

            if (User.Identity.IsAuthenticated)
            {
                var currentUser = UserManager.GetUserId(User);
                var BalanceDup = from n in Context.MiscRule
                                 where n.OwnerID == currentUser
                                 select n;

                var BalanceDup2 = BalanceDup.ToList();
                if (BalanceDup2.Count == 0)
                {
                    return RedirectToPage("/Rules/Misc/Create");
                }

                toRedirect = "/Rules/Misc/Edit";
                return RedirectToPage(toRedirect);
            }
            return RedirectToPage("/Index");
        }
    }
}
