using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Notifier.Data;
using Notifier.Models;

namespace Notifier.Pages.Rules.Location
{
    public class DetailsModel : PageModel
    {
        private readonly Notifier.Data.ApplicationDbContext _context;

        public DetailsModel(Notifier.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public LocationRule LocationRule { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LocationRule = await _context.LocationRule.FirstOrDefaultAsync(m => m.LocationRuleID == id);

            if (LocationRule == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
