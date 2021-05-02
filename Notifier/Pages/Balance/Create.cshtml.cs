using Notifier.Authorization;
using Notifier.Data;
using Notifier.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Notifier.Pages.Balance
{
    #region snippetCtor
    public class CreateModel : CI_BasePageModel
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
            var currentUser = UserManager.GetUserId(User);
            var BalanceDup = from n in Context.BalanceModel
                             where n.OwnerID == currentUser
                             select n;

            var BalanceDup2 = BalanceDup.ToList();

            for(int i = 0; i < BalanceDup2.Count(); i++)
            {
                if(BalanceDup2[i].OwnerID == currentUser)
                {
                    return Forbid();
                }
            }

            return Page();
        }

        [BindProperty]
        public BalanceModel BalanceModel { get; set; }

        #region snippet_Create
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var currentUser = UserManager.GetUserId(User);
            BalanceModel.OwnerID = currentUser;

            /*
            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                        User, BalanceModel,
                                                        TransactionOperations.Create);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }
            */

            Context.BalanceModel.Add(BalanceModel);
            await Context.SaveChangesAsync();

            var BalanceDup = from n in Context.BalanceModel
                             where n.OwnerID == currentUser
                             select n;

            var BalanceDup2 = BalanceDup.ToList();
            var currBalance = BalanceDup2[0];
            for (int i = 0; i < BalanceDup2.Count(); i++)
            {
                if (BalanceDup2[i].OwnerID == currentUser)
                {
                    currBalance = BalanceDup2[i];
                }
            }
            DateTime currentTime = DateTime.Now;
            var initialTransaction = new Transaction { OwnerID = currentUser, DepositWithdrawl = (DepoType)1, Balance = currBalance.BalanceAmount, Description = "Initial Balance", TransactionDate = currentTime, TransAmount = currBalance.BalanceAmount };
            Context.Transaction.Add(initialTransaction);
            await Context.SaveChangesAsync();

            return RedirectToPage("/Dashboard");
        }
        #endregion
    }
}