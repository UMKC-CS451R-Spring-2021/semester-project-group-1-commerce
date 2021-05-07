using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Notifier.Authorization;
using Notifier.Data;
using Notifier.Models;

namespace Notifier.Pages
{
    [AllowAnonymous]
    public class IndexModel : XI_BasePageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(
                ApplicationDbContext context,
                IAuthorizationService authorizationService,
                  UserManager<IdentityUser> userManager)
                 : base(context, authorizationService, userManager)
            {
            }

        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                var currentUser = UserManager.GetUserId(User);
                var BalanceDup = from n in Context.BalanceModel
                                 where n.OwnerID == currentUser
                                 select n;

                var BalanceDup2 = BalanceDup.ToList();
                if(BalanceDup2.Count == 0)
                {
                    return RedirectToPage("/Balance/Create");
                }
                return RedirectToPage("/Dashboard");
            }
            return Page();
        }
    }
}
