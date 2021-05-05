using Notifier.Authorization;
using Notifier.Data;
using Notifier.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Notifier.PagesTransactions
{
    #region snippetCtor
    public class CreateModel : DI_BasePageModel
    {
        public CreateModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }
        #endregion

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Transaction Transaction { get; set; }

        #region snippet_Create
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Transaction.OwnerID = UserManager.GetUserId(User);

            // requires using ContactManager.Authorization;
            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                        User, Transaction,
                                                        TransactionOperations.Create);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            Context.Transaction.Add(Transaction);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        #endregion
    }
}