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
    public class EditModel : CI_BasePageModel
    {
        public EditModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }
        [BindProperty]
        public MiscRule MiscRule { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var currentUser = UserManager.GetUserId(User);
            var BalanceDup = from n in Context.MiscRule
                             where n.OwnerID == currentUser
                             select n;

            var BalanceDup2 = BalanceDup.ToList();

            MiscRule = await Context.MiscRule.FirstOrDefaultAsync(m => m.MiscRuleID == BalanceDup2[0].MiscRuleID);

            if (MiscRule == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Context.Attach(MiscRule).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MiscRuleExists(MiscRule.MiscRuleID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MiscRuleExists(int id)
        {
            return Context.MiscRule.Any(e => e.MiscRuleID == id);
        }
    }
}
