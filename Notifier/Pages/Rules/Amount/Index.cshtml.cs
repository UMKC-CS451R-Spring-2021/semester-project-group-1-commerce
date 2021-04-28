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
    public class IndexModel : PageModel
    {
        private readonly Notifier.Data.ApplicationDbContext _context;

        public IndexModel(Notifier.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AmountRule> AmountRule { get;set; }

        public async Task OnGetAsync()
        {
            AmountRule = await _context.AmountRule.ToListAsync();
        }
    }
}
