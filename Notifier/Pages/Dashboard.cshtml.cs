using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Notifier.Authorization;
using Notifier.Data;
using Notifier.Models;

namespace Notifier.Pages
{

    public class DashboardModel : PageModel
    {
        private readonly IConfiguration Configuration;

        public DashboardModel(
                ApplicationDbContext context,
                IConfiguration configuration,
                IAuthorizationService authorizationService,
                UserManager<IdentityUser> userManager) : base()
        {
            Context = context;
            UserManager = userManager;
            Configuration = configuration;
            AuthorizationService = authorizationService;
        }
        protected ApplicationDbContext Context { get; }
        protected IAuthorizationService AuthorizationService { get; }
        protected UserManager<IdentityUser> UserManager { get; }
        public PaginatedList<Transaction> Transaction { get; set; }
        public decimal MyBalance { get; set; }
        public string MyName { get; set; }

        public string DateSort { get; set; }

        public async Task OnGetAsync(string sortOrder, int? pageIndex)
        {

            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            var UserID = UserManager.GetUserId(User);

            var BalanceDup = from n in Context.BalanceModel
                             where n.OwnerID == UserID
                             select n;

            var UserDup = BalanceDup.ToList();

            for (int i = 0; i < UserDup.Count(); i++)
            {
                if (UserDup[i].OwnerID == UserID)
                {
                    MyBalance = UserDup[i].BalanceAmount;
                    MyName = UserDup[i].OwnerName;
                }
            }

            var Transactions = from c in Context.Transaction
                               where c.OwnerID == UserID
                               select c;

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

            var pageSize = Configuration.GetValue("PageSize", 5);
            Transaction = await PaginatedList<Transaction>.CreateAsync(
                Transactions, pageIndex ?? 1, pageSize);
        }
    }
}

