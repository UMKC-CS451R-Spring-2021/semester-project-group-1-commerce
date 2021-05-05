using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Notifier.Data;
using Notifier.Models;

namespace Notifier.Pages.Rules
{
    public class EditModel : PageModel
    {
        private readonly Notifier.Data.ApplicationDbContext _context;

        public EditModel(Notifier.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(NotificationRule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificationRuleExists(NotificationRule.RuleID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NotificationRuleExists(int id)
        {
            return _context.NotificationRule.Any(e => e.RuleID == id);
        }
    }
}
