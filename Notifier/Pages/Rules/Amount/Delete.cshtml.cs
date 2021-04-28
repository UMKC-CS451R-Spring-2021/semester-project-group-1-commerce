using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Notifier.Data;
using Notifier.Models;

namespace Notifier.Pages.Rules.Amount
{
    public class DeleteModel : PageModel
    {
        private readonly Notifier.Data.ApplicationDbContext _context;

        public DeleteModel(Notifier.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AmountRule AmountRule { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AmountRule = await _context.AmountRule.FirstOrDefaultAsync(m => m.AmountRuleID == id);

            if (AmountRule == null)
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

            AmountRule = await _context.AmountRule.FindAsync(id);

            if (AmountRule != null)
            {
                _context.AmountRule.Remove(AmountRule);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
