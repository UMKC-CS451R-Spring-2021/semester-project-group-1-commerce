using Notifier.Data;
using Notifier.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifier.Pages.Rules.Location
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

        public IList<LocationRule> LocationRule { get;set; }

        public async Task OnGetAsync()
        {
            var currentUserId = UserManager.GetUserId(User);
            var getRuleLocation = from l in Context.LocationRule
                                  where l.OwnerID == currentUserId
                                  select l;

            LocationRule = await getRuleLocation.ToListAsync();
        }
    }
}
