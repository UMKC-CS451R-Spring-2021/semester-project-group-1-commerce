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

            DateTime currentTime = DateTime.Now;
            var UserID = UserManager.GetUserId(User);
            Transaction.OwnerID = UserID;
            var balanceAmt = Transaction.TransAmount;

            var BalanceDup = from n in Context.BalanceModel
                             where n.OwnerID == UserID
                             select n;

            var MiscDup =    from n in Context.MiscRule
                             where n.OwnerID == UserID
                             select n;

            var UserDup = BalanceDup.ToList();
            var RuleDup = MiscDup.ToList();

            var ruleCheckMisc = RuleDup[0];
            var BalanceToPutIn = UserDup[0].BalanceAmount;
            var BalanceIndex = UserDup[0].BalanceID;
            

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
                    if (ruleCheckMisc.wantOverdraft == true)
                    {
                    var newNotification = new Notification { OwnerID = UserID, IsRead = false, transactionID = marker.TransactionId, Reason = "Account Overdrawn", CreationDate = currentTime, Type = "Overdraw" };
                    Context.Notification.Add(newNotification);
                    }
                }
                else
                {
                    marker.Balance = BalanceToPutIn - balanceAmt;
                    if (ruleCheckMisc.wantAllWithdraw == true)
                    {
                        var newNotification = new Notification { OwnerID = UserID, IsRead = false, transactionID = marker.TransactionId, Reason = "New Withdraw", CreationDate = currentTime, Type = "Withdraw" };
                        Context.Notification.Add(newNotification);
                    }
                }
            }

            else if (marker.DepositWithdrawl == (DepoType)1)
            {
                marker.Balance = BalanceToPutIn + balanceAmt;
                if (ruleCheckMisc.wantAllDeposit == true)
                {
                    var newNotification = new Notification { OwnerID = UserID, IsRead = false, transactionID = marker.TransactionId, Reason = "New Deposit", CreationDate = currentTime, Type = "Deposit" };
                    Context.Notification.Add(newNotification);
                }
            }

            var balanceToSave = await Context.BalanceModel.FindAsync(BalanceIndex);
            balanceToSave.BalanceAmount = marker.Balance;

            Context.SaveChanges();
            return RedirectToPage("./Index");
        }
        #endregion
    }
}