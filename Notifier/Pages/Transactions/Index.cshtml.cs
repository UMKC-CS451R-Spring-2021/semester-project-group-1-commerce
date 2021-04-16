using Notifier.Data;
using Notifier.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifier.PagesTransactions
{
    #region snippet
    public class IndexModel : DI_BasePageModel
    {
        public IndexModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        public string DateSort { get; set; }
        public string CurrentSort { get; set; }

        public IList<Transaction> Transaction { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            var Transactions = from c in Context.Transaction
                           select c;

            // var isAuthorized = User.IsInRole(Constants.ContactAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);

            // Only approved contacts are shown UNLESS you're authorized to see them
            // or you are the owner.
            // if (!isAuthorized)
            // {
                Transactions = Transactions.Where(c => c.OwnerID == currentUserId);
            // }

            switch (sortOrder)
            {
                case "Date":
                    Transactions = Transactions.OrderBy(s => s.TransactionDate);
                    break;
                case "date_desc":
                    Transactions = Transactions.OrderByDescending(s => s.TransactionDate);
                    break;
                default:
                    Transactions = Transactions.OrderByDescending(s => s.TransactionDate);
                    break;
            }


            Transaction = await Transactions.ToListAsync();
        }
    }
    #endregion
}