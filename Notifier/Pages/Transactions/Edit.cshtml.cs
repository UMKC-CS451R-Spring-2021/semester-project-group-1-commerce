using Notifier.Authorization;
using Notifier.Data;
using Notifier.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Notifier.PagesTransactions
{
    #region snippet
    public class EditModel : DI_BasePageModel
    {
        public EditModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        [BindProperty]
        public Transaction Transaction { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Transaction = await Context.Transaction.FirstOrDefaultAsync(
                                                 m => m.TransactionId == id);

            if (Transaction == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                      User, Transaction,
                                                      TransactionOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Fetch Transaction from DB to get OwnerID.
            var Transaction = await Context
                .Transaction.AsNoTracking()
                .FirstOrDefaultAsync(m => m.TransactionId == id);

            if (Transaction == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, Transaction,
                                                     TransactionOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            Transaction.OwnerID = Transaction.OwnerID;

            Context.Attach(Transaction).State = EntityState.Modified;

            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
    #endregion
}