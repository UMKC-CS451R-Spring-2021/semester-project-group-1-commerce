using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Notifier.Data;
using Notifier.Models;

namespace Notifier.Pages.Notifications
{
    public class DetailsModel : PageModel
    {
        private readonly Notifier.Data.ApplicationDbContext _context;

        public DetailsModel(Notifier.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Notification Notification { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Notification = await _context.Notification.FirstOrDefaultAsync(m => m.NotificationID == id);

            if (Notification == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
