using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Notifier.Data;
using Notifier.Models;

namespace Notifier.Pages.Rules
{
    public class IndexModel : PageModel
    {
        private readonly Notifier.Data.ApplicationDbContext _context;

        public IndexModel(Notifier.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<NotificationRule> NotificationRule { get;set; }

        public async Task OnGetAsync()
        {
            NotificationRule = await _context.NotificationRule.ToListAsync();
        }
    }
}
