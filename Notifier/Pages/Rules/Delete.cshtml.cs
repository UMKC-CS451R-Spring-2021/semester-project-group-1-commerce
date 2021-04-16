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
    public class DeleteModel : PageModel
    {
        private readonly Notifier.Data.ApplicationDbContext _context;

        public DeleteModel(Notifier.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public NotificationRule NotificationRule { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NotificationRule = await _context.NotificationRule.FirstOrDefaultAsync(m => m.RuleID == id);

            if (NotificationRule == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NotificationRule = await _context.NotificationRule.FindAsync(id);

            if (NotificationRule != null)
            {
                _context.NotificationRule.Remove(NotificationRule);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
