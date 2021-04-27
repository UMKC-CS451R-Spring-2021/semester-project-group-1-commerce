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

        public IList<Notification> Notification { get;set; }

        public async Task OnGetAsync()
        {

            var currentUserId = UserManager.GetUserId(User);
            DateTime currentTime = DateTime.Now;

            var matcchedTransactions = from t in Context.Transaction
                                       from r in Context.NotificationRule
                                       where t.Location.Contains(r.LocationFilter) && t.OwnerID == currentUserId
                                       select t;

            var allNotifications = from n in Context.Notification
                                   select n;

            FilteredList = matcchedTransactions.ToList();
            Notification = allNotifications.ToList();
            /*
            var locationTransactions = from t in Context.Transaction
                                       from r in Context.Location
                                       where t.Location.Contains(r.location) && t.OwnerID == currentUserId
                                       select t;

            var descriptionTransactions = from t in Context.Transaction
                                          from r in Context.Description
                                          where t.Description.Contains(r.description) && t.OwnerID == currentUserId
                                          select t;

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

            //var newNotification = new Notification { OwnerID = FilteredList[0].OwnerID, IsRead = false, transactionID = FilteredList[0].TransactionId, Reason = ("Transaction from: " + FilteredList[0].Location), CreationDate = currentTime };
            //Context.Notification.Add(newNotification);
            Context.SaveChanges();
            Notification = await Context.Notification.ToListAsync();
        }
    }
}

