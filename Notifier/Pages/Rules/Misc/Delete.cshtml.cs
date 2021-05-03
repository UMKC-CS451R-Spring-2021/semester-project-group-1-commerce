using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Notifier.Data;
using Notifier.Models;

namespace Notifier.Pages.Rules.Misc
{
    public class DeleteModel : PageModel
    {
        private readonly Notifier.Data.ApplicationDbContext _context;

        public DeleteModel(Notifier.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MiscRule MiscRule { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MiscRule = await _context.MiscRule.FirstOrDefaultAsync(m => m.MiscRuleID == id);

            if (MiscRule == null)
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

            MiscRule = await _context.MiscRule.FindAsync(id);

            if (MiscRule != null)
            {
                _context.MiscRule.Remove(MiscRule);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
