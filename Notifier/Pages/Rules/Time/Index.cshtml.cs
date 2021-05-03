using Notifier.Data;
using Notifier.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifier.Pages.Rules.Time
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

        public IList<TimeRule> TimeRule { get; set; }

        public async Task OnGetAsync()
        {
            var currentUserId = UserManager.GetUserId(User);
            var getRuleLocation = from l in Context.TimeRule
                                  where l.OwnerID == currentUserId
                                  select l;

            TimeRule = await getRuleLocation.ToListAsync();
        }
    }
}
