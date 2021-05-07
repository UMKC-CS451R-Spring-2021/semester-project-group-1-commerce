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
        public MiscRule ruleCheckMisc { get; set; }

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

            var LocationRules = from r in Context.LocationRule
                                       where r.OwnerID == UserID
                                       select r.location;

            var DescriptionRules = from r in Context.DescriptionRule
                                   where r.OwnerID == UserID
                                   select r.descriptionNotification;

            var AmountRules = from r in Context.AmountRule
                                       where r.OwnerID == UserID
                                       select r;

            var TimeRules = from r in Context.TimeRule
                              where r.OwnerID == UserID
                              select r;


            var UserDup = BalanceDup.ToList();
            var RuleDup = MiscDup.ToList();
            var LocDup = LocationRules.ToList();
            var DescDup = DescriptionRules.ToList();
            var AmountDup = AmountRules.ToList();
            var TimeDup = TimeRules.ToList();

            if (RuleDup.Count > 0)
            {
                ruleCheckMisc = RuleDup[0];
            }
            else 
            {
                ruleCheckMisc = new MiscRule { wantAllDeposit = false, wantAllWithdraw = false, wantOverdraft = false };
            }

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

            for(int i = 0; i < LocDup.Count; i++)
            {
                if(marker.Location.Contains(LocDup[i]))
                    {
                    var newNotification = new Notification { OwnerID = marker.OwnerID, IsRead = false, transactionID = marker.TransactionId, Reason = ("Transaction from: " + marker.Location), CreationDate = currentTime, Type = "Location" };
                    Context.Notification.Add(newNotification);
                    }
            }

            for (int i = 0; i < LocDup.Count; i++)
            {
                if (marker.Description.Contains(DescDup[i]))
                {
                    var newNotification = new Notification { OwnerID = marker.OwnerID, IsRead = false, transactionID = marker.TransactionId, Reason = ("Transaction of: " + marker.Description), CreationDate = currentTime, Type = "Description" };
                    Context.Notification.Add(newNotification);
                }
            }

            for (int i = 0; i < AmountDup.Count; i++)
            {
                if (marker.DepositWithdrawl == (DepoType)1)
                {
                    if (AmountDup[i].GreaterLess == (NumComparator)1 && marker.TransAmount > AmountDup[i].amountNotification)
                    {
                        var newNotification = new Notification { OwnerID = marker.OwnerID, IsRead = false, transactionID = marker.TransactionId, Reason = ("Deposit above: $" + marker.TransAmount), CreationDate = currentTime, Type = "Amount" };
                        Context.Notification.Add(newNotification);
                    }

                    else if (AmountDup[i].GreaterLess == (NumComparator)2 && marker.TransAmount < AmountDup[i].amountNotification)
                    {
                        var newNotification = new Notification { OwnerID = marker.OwnerID, IsRead = false, transactionID = marker.TransactionId, Reason = ("Deposit below: $" + marker.TransAmount), CreationDate = currentTime, Type = "Amount" };
                        Context.Notification.Add(newNotification);
                    }

                    else if (AmountDup[i].GreaterLess == (NumComparator)3 && marker.TransAmount == AmountDup[i].amountNotification)
                    {
                        var newNotification = new Notification { OwnerID = marker.OwnerID, IsRead = false, transactionID = marker.TransactionId, Reason = ("Deposit of exactly: $" + marker.TransAmount), CreationDate = currentTime, Type = "Amount" };
                        Context.Notification.Add(newNotification);
                    }
                }
                else if (marker.DepositWithdrawl == (DepoType)2)
                {
                    if (AmountDup[i].GreaterLess == (NumComparator)1 && marker.TransAmount > AmountDup[i].amountNotification)
                    {
                        var newNotification = new Notification { OwnerID = marker.OwnerID, IsRead = false, transactionID = marker.TransactionId, Reason = ("Withdraw above: $" + marker.TransAmount), CreationDate = currentTime, Type = "Amount" };
                        Context.Notification.Add(newNotification);
                    }

                    else if (AmountDup[i].GreaterLess == (NumComparator)2 && marker.TransAmount < AmountDup[i].amountNotification)
                    {
                        var newNotification = new Notification { OwnerID = marker.OwnerID, IsRead = false, transactionID = marker.TransactionId, Reason = ("Withdraw below: $" + marker.TransAmount), CreationDate = currentTime, Type = "Amount" };
                        Context.Notification.Add(newNotification);
                    }

                    else if (AmountDup[i].GreaterLess == (NumComparator)3 && marker.TransAmount == AmountDup[i].amountNotification)
                    {
                        var newNotification = new Notification { OwnerID = marker.OwnerID, IsRead = false, transactionID = marker.TransactionId, Reason = ("Withdraw of exactly: $" + marker.TransAmount), CreationDate = currentTime, Type = "Amount" };
                        Context.Notification.Add(newNotification);
                    }
                }
            }
            for (int i = 0; i < TimeDup.Count; i++)
            {
                TimeSpan OlderTime = TimeSpan.Zero;
                TimeSpan NewerTime = TimeSpan.Zero;
                var TimeCompare = marker.TransactionDate.TimeOfDay;
                if (TimeDup[i].TransactionTimeFilterFrom >= TimeDup[i].TransactionTimeFilterUntil)
                {
                    OlderTime = TimeDup[i].TransactionTimeFilterUntil.TimeOfDay;
                    NewerTime = TimeDup[i].TransactionTimeFilterFrom.TimeOfDay;
                    if (TimeCompare < OlderTime || TimeCompare > NewerTime)
                    {
                        var newNotification = new Notification { OwnerID = marker.OwnerID, IsRead = false, transactionID = marker.TransactionId, Reason = ("Transaction detected between: " + TimeDup[i].TransactionTimeFilterFrom.ToString("h:mm tt") + " and " + TimeDup[i].TransactionTimeFilterUntil.ToString("h:mm tt")), CreationDate = currentTime, Type = "Time" };
                        Context.Notification.Add(newNotification);
                    }
                }
                else
                {
                    OlderTime = TimeDup[i].TransactionTimeFilterFrom.TimeOfDay;
                    NewerTime = TimeDup[i].TransactionTimeFilterUntil.TimeOfDay;
                    if (TimeCompare >= OlderTime && TimeCompare <= NewerTime)
                    {
                        var newNotification = new Notification { OwnerID = marker.OwnerID, IsRead = false, transactionID = marker.TransactionId, Reason = ("Transaction detected between: " + TimeDup[i].TransactionTimeFilterFrom.ToString("h:mm tt") + " and " + TimeDup[i].TransactionTimeFilterUntil.ToString("h:mm tt")), CreationDate = currentTime, Type = "Time" };
                        Context.Notification.Add(newNotification);
                    }
                }
            }
            Context.SaveChanges();
            return RedirectToPage("./Index");
        }
        #endregion
    }
}