using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notifier.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Notifier.Data;
using System;

namespace Notifier.Pages.Notifications
{
    public class IndexModel : PagesTransactions.DI_BasePageModel
    {

        public IndexModel(
        ApplicationDbContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        public IList<Transaction> Transaction { get; set; }

        public IList<Transaction> FilteredList { get; set; }

        public IList<Transaction> DescriptionList { get; set; }

        public IList<Notification> Notification { get;set; }

        public async Task OnGetAsync()
        {

            var currentUserId = UserManager.GetUserId(User);
            DateTime currentTime = DateTime.Now;

            var locationTransactions = from t in Context.Transaction
                                       from r in Context.LocationRule
                                       where t.Location.Contains(r.location) && t.OwnerID == currentUserId
                                       select t;

            var descriptionTransactions = from t in Context.Transaction
                                          from r in Context.DescriptionRule
                                          where t.Description.Contains(r.descriptionNotification) && t.OwnerID == currentUserId
                                          select t;

            var allNotifications = from n in Context.Notification
                                   select n;

            FilteredList = locationTransactions.ToList();
            DescriptionList = descriptionTransactions.ToList();
            Notification = allNotifications.ToList();
            /*



            var amountTransactions = from t in Context.Transaction
                                     from r in Context.Amount
                                     where (r.GreaterLess == (NumComparator)1 && t.TransAmount > r.amount)
                                     || (r.GreaterLess == (NumComparator)2 && t.TransAmount < r.amount)
                                     || (r.GreaterLess == (NumComparator)3 && t.TransAmount == r.amount)
                                     && t.OwnerID == currentUserId
                                     select t;

            var timeTransactions = from t in Context.Transaction
                                   from r in Context.Time
                                   where (r.BeforeAfterTime == (TimeShare)1 && t.TransactionTime > r.TransactionTimeFilter)
                                   || (r.BeforeAfterTime == (TimeShare)2 && t.TransactionTime < r.TransactionTimeFilter)
                                   || (r.BeforeAfterTime == (TimeShare)3 && t.TransactionTime == r.TransactionTimeFilter)
                                   && t.OwnerID == currentUserId
                                   select t;
            */

            //create Location Notifications
            for (int i = 0; i < FilteredList.Count; i++)
            {
                bool isDuplicate = false;

                for (int k = 0; k < Notification.Count; k++)
                {
                    if ((Notification[k].transactionID == FilteredList[i].TransactionId) && (Notification[k].Reason == ("Transaction from: " + FilteredList[i].Location)))
                    {
                        isDuplicate = true;
                    }
                }

                if (isDuplicate == false)
                {
                    var newNotification = new Notification { OwnerID = FilteredList[i].OwnerID, IsRead = false, transactionID = FilteredList[i].TransactionId, Reason = ("Transaction from: " + FilteredList[i].Location), CreationDate = currentTime };
                    Context.Notification.Add(newNotification);
                }
            }

            allNotifications = from n in Context.Notification
                               select n;

            Notification = allNotifications.ToList();

            //description notifications
            for (int i = 0; i < DescriptionList.Count; i++)
            {
                bool isDuplicate = false;

                for (int k = 0; k < Notification.Count; k++)
                {
                    if ((Notification[k].transactionID == DescriptionList[i].TransactionId) && (Notification[k].Reason == ("Transaction of: " + DescriptionList[i].Description)))
                    {
                        isDuplicate = true;
                    }
                }

                if (isDuplicate == false)
                {
                    var newNotification = new Notification { OwnerID = DescriptionList[i].OwnerID, IsRead = false, transactionID = DescriptionList[i].TransactionId, Reason = ("Transaction of: " + DescriptionList[i].Description), CreationDate = currentTime };
                    Context.Notification.Add(newNotification);
                }
            }

            Context.SaveChanges();
            Notification = await Context.Notification.ToListAsync();
        }
    }
}

