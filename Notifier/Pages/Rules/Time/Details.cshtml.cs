using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Notifier.Data;
using Notifier.Models;

namespace Notifier.Pages.Rules.Time
{
    public class DetailsModel : PageModel
    {
        private readonly Notifier.Data.ApplicationDbContext _context;

        public DetailsModel(Notifier.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public TimeRule TimeRule { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TimeRule = await _context.TimeRule.FirstOrDefaultAsync(m => m.TimeRuleID == id);

            if (TimeRule == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
