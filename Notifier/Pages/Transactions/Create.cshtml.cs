using Notifier.Authorization;
using Notifier.Data;
using Notifier.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System.Linq;

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

            var UserID = UserManager.GetUserId(User);
            Transaction.OwnerID = UserID;
            var balanceAmt = Transaction.TransAmount;

            var BalanceDup = from n in Context.BalanceModel
                             where n.OwnerID == UserID
                             select n;

            var UserDup = BalanceDup.ToList();
            var BalanceToPutIn = UserDup[0].BalanceAmount;
            var BalanceIndex = UserDup[0].BalanceID;

            for (int i = 0; i < UserDup.Count(); i++)
            {
                if (UserDup[i].OwnerID == UserID)
                {
                    BalanceToPutIn = UserDup[i].BalanceAmount;
                    BalanceIndex = UserDup[i].BalanceID;
                }
            }
            

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                        User, Transaction,
                                                        TransactionOperations.Create);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            Context.Transaction.Add(Transaction);
            Context.SaveChanges();

            var marker = await Context.Transaction.FindAsync(Transaction.TransactionId);

            if (marker.DepositWithdrawl == (DepoType)2)
            {
                if (BalanceToPutIn - balanceAmt < 0)
                {
                    if (BalanceToPutIn - 35 < 0)
                    {
                        marker.Balance = 0;
                    }
                    else
                    {
                        marker.Balance = BalanceToPutIn - 35;
                    }
                    marker.Description = marker.Description + " (OVERDRAWN)";
                }
                else
                {
                    marker.Balance = BalanceToPutIn - balanceAmt;
                }
            }

            else if (marker.DepositWithdrawl == (DepoType)1)
            {
                marker.Balance = BalanceToPutIn + balanceAmt;
            }

            var balanceToSave = await Context.BalanceModel.FindAsync(BalanceIndex);
            balanceToSave.BalanceAmount = marker.Balance;

            Context.SaveChanges();
            return RedirectToPage("./Index");
        }
        #endregion
    }
}