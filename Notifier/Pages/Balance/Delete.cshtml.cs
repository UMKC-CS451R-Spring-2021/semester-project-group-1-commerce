using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Notifier.Data;
using Notifier.Models;

namespace Notifier.Pages.Balance
{
    public class DeleteModel : PageModel
    {
        private readonly Notifier.Data.ApplicationDbContext _context;

        public DeleteModel(Notifier.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BalanceModel BalanceModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BalanceModel = await _context.BalanceModel.FirstOrDefaultAsync(m => m.BalanceID == id);

            if (BalanceModel == null)
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

            BalanceModel = await _context.BalanceModel.FindAsync(id);

            if (BalanceModel != null)
            {
                _context.BalanceModel.Remove(BalanceModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
