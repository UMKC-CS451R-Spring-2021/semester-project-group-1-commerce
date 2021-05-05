using Notifier.Authorization;
using Notifier.Data;
using Notifier.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Notifier.PagesTransactions
{
    #region snippet
    public class DeleteModel : DI_BasePageModel
    {
        public DeleteModel(
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
                                                     TransactionOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var Transaction = await Context
                .Transaction.AsNoTracking()
                .FirstOrDefaultAsync(m => m.TransactionId == id);

            if (Transaction == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, Transaction,
                                                     TransactionOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            Context.Transaction.Remove(Transaction);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
    #endregion
}