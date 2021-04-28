using Notifier.Data;
using Notifier.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifier.Pages.Rules.Description
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

        public IList<DescriptionRule> DescriptionRule { get; set; }

        public async Task OnGetAsync()
        {
            var currentUserId = UserManager.GetUserId(User);
            var getRuleDescription = from l in Context.DescriptionRule
                                  where l.OwnerID == currentUserId
                                  select l;

            DescriptionRule = await getRuleDescription.ToListAsync();
        }
    }
}
