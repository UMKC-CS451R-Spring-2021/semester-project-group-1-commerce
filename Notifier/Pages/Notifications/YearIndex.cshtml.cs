using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notifier.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Notifier.Data;
using System;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using OfficeOpenXml;

namespace Notifier.Pages.Notifications
{
    public class IndexYearModel : PagesTransactions.DI_BasePageModel
    {

        public IndexYearModel(
        ApplicationDbContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        public IList<Notification> Notification { get; set; }

        public async Task OnGetAsync()
        {

            var currentUserId = UserManager.GetUserId(User);
            var lastYear = DateTime.Today.AddYears(-1);

            var UnreadNotifications = from n in Context.Notification
                                      where n.CreationDate > lastYear && n.OwnerID == currentUserId
                                      select n;

            Notification = await UnreadNotifications.ToListAsync();
        }

        public async Task<IActionResult> OnPostExportAsync()
        {
            var UserID = UserManager.GetUserId(User);
            var lastYear = DateTime.Today.AddYears(-1);


            var NotifsList = from n in Context.Notification
                             where n.OwnerID == UserID && n.CreationDate > lastYear
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

            string excelName = $"YearNotificationReport-{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx";
            // above I define the name of the file using the current datetime.

            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName); // this will be the actual export.
        }
    }
}
