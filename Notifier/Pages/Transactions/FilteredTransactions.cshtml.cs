using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notifier.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Notifier.Data;

namespace Notifier.Pages.Transactions
{
    public class FilteredTransactionsModel : PagesTransactions.DI_BasePageModel
    {
        //private readonly ApplicationDbContext _context;

        public FilteredTransactionsModel(
        ApplicationDbContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        public IList<Transaction> Transaction { get;set; }

        public async Task OnGetAsync()
        {
                var Transactions = from c in Context.Transaction
                                   select c;

                var currentUserId = UserManager.GetUserId(User);

                Transactions = Transactions.Where(c => c.Location.Contains("SPAIN")
                                       && c.OwnerID == currentUserId);

                Transaction = await Transactions.ToListAsync();
        }
    }
}
