using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notifier.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Notifier.Data;
using Microsoft.AspNetCore.Mvc;

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

        public IList<Transaction> AmountGreaterList { get; set; }
        public IList<Transaction> AmountLessList { get; set; }
        public IList<Transaction> AmountEqualList { get; set; }

        public IList<Notification> Notification { get;set; }

        public async Task OnGetAsync()
        {

            var currentUserId = UserManager.GetUserId(User);

            var UnreadNotifications = from n in Context.Notification
                                      where n.IsRead == false && n.OwnerID == currentUserId
                                      select n;

            Notification = await UnreadNotifications.ToListAsync();
        }
        public async Task<IActionResult> OnPostReadAsync(int id)
        {
            var marker = await Context.Notification.FindAsync(id);

            if (marker != null)
            {
                marker.IsRead = true;
                await Context.SaveChangesAsync();
            }
            return RedirectToPage("");
        }

        public async Task<IActionResult> OnPostFlushAsync()
        {
            var currentUserId = UserManager.GetUserId(User);

            var allNotifications = from n in Context.Notification
                                   where n.OwnerID == currentUserId
                                   select n;

           var notifList = await allNotifications.ToListAsync();

            for(int i = 0; i < notifList.Count; i++)
            {
                var marker = await Context.Notification.FindAsync(notifList[i].NotificationID);
                marker.IsRead = true;
            }

                await Context.SaveChangesAsync();

            return RedirectToPage("");
        }
    }

}

