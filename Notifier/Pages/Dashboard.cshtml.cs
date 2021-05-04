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
using System.Text;
using System.IO;
using OfficeOpenXml;

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
        public IList<TempRuleCount> RuleCount { get; set; }
        public string DateSort { get; set; }
        public int UnreadNotifications { get; set; }
        public async Task OnGetAsync(string sortOrder, int? pageIndex)
        {

            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            var UserID = UserManager.GetUserId(User);

            var BalanceDup = from n in Context.BalanceModel
                             where n.OwnerID == UserID
                             select n;

            var UserDup = BalanceDup.ToList();

            MyBalance = UserDup[0].BalanceAmount;
            MyName = UserDup[0].OwnerName;

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

            var RuleCountSetup = from r in Context.TempRuleCount
                                 select r;

            RuleCount = RuleCountSetup.ToList();

            IList<string> Types = new List<string>();
            Types.Add("Location");
            Types.Add("Description");
            Types.Add("Amount");
            Types.Add("Time");
            Types.Add("Overdraw");
            Types.Add("Deposit");
            Types.Add("Withdraw");
            CompileList(Types);
            GetUnread();

            var pageSize = Configuration.GetValue("PageSize", RuleCount.Count);
            Transaction = await PaginatedList<Transaction>.CreateAsync(
                Transactions, pageIndex ?? 1, pageSize);
        }

        public void GetUnread()
        {
            var UserID = UserManager.GetUserId(User);
            var Unread = from n in Context.Notification
                         where n.IsRead == false && n.OwnerID == UserID
                         select n;

            UnreadNotifications = Unread.ToList().Count;
        }

        public void CompileList(IList<string> Types)
        {
            var lastMonth = DateTime.Today.AddMonths(-1);
            var lastYear = DateTime.Today.AddYears(-1);
            var UserID = UserManager.GetUserId(User);

            for (int k = 0; k < Types.Count; k++)
            {
                var LocationMonth = from n in Context.Notification
                                    where n.Type.Contains(Types[k]) && n.CreationDate > lastMonth && n.OwnerID == UserID
                                    select n;

                var LocationYear = from n in Context.Notification
                                   where n.Type.Contains(Types[k]) && n.CreationDate > lastYear && n.OwnerID == UserID
                                   select n;

                var LocationUnread = from n in Context.Notification
                                     where n.Type.Contains(Types[k]) && n.IsRead == false && n.OwnerID == UserID
                                     select n;

                IList<Notification> LocationMonthList = LocationMonth.ToList();
                IList<Notification> LocationYearList = LocationYear.ToList();
                IList<Notification> LocationUnreadList = LocationUnread.ToList();

                if (LocationYearList.Count > 0)
                {
                    int month = LocationMonthList.Count;
                    var TempThing = new TempRuleCount { RuleType = Types[k], TriggeredThisMonth = LocationMonthList.Count, TriggeredThisYear = LocationYearList.Count, Unread = LocationUnreadList.Count };
                    RuleCount.Add(TempThing);
                }
            }
        }

        public async Task<IActionResult> OnPostExportAsync()
        {
            var UserID = UserManager.GetUserId(User);

            var NotifsList = from n in Context.Notification
                        where n.OwnerID == UserID
                        select new { n.Type, n.Reason, Date_Created = n.CreationDate.ToString("f"), n.IsRead };

            var myBUs = NotifsList.ToList();

            // above code loads the data using LINQ with EF (query of table), you can substitute this with any data source.
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(myBUs, true);
                package.Save();
            }
            stream.Position = 0;

            string excelName = $"CompleteNotificationReport-{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx";
            // above I define the name of the file using the current datetime.

            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName); // this will be the actual export.
        }
    }
}

