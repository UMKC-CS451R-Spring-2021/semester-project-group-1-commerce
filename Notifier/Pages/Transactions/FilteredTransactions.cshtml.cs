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

        public IList<Transaction> FilteredList { get; set; }



        public async Task OnGetAsync()
        {

            var currentUserId = UserManager.GetUserId(User);

            var matcchedTransactions = from t in Context.Transaction
                                       from r in Context.NotificationRule
                                       where t.Location.Contains(r.LocationFilter) && t.OwnerID == currentUserId
                                       select t;

            var locationTransactions = from t in Context.Transaction
                                       from r in Context.Location
                                       where t.Location.Contains(r.location) && t.OwnerID == currentUserId
                                       select t;

            var descriptionTransactions = from t in Context.Transaction
                                          from r in Context.Description
                                          where t.Description.Contains(r.description) && t.OwnerID == currentUserId
                                          select t;

            var amountTransactions =      from t in Context.Transaction
                                          from r in Context.Amount
                                          where (r.GreaterLess == (NumComparator)1 && t.TransAmount > r.amount) 
                                          || (r.GreaterLess == (NumComparator)2 && t.TransAmount < r.amount) 
                                          || (r.GreaterLess == (NumComparator)3 && t.TransAmount == r.amount)
                                          && t.OwnerID == currentUserId
                                          select t;

           var timeTransactions =         from t in Context.Transaction
                                          from r in Context.Time
                                          where (r.BeforeAfterTime == (TimeShare)1 && t.TransactionTime > r.TransactionTimeFilter)
                                          || (r.BeforeAfterTime == (TimeShare)2 && t.TransactionTime < r.TransactionTimeFilter)
                                          || (r.BeforeAfterTime == (TimeShare)3 && t.TransactionTime == r.TransactionTimeFilter)
                                          && t.OwnerID == currentUserId
                                          select t;

            Transaction = await matcchedTransactions.ToListAsync();
        }
    }
}
