﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Notifier.Data;
using Notifier.Models;

namespace Notifier.Pages.Notifications
{
    public class CreateModel : PageModel
    {
        private readonly Notifier.Data.ApplicationDbContext _context;

        public CreateModel(Notifier.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {

            return Page();
        }

        [BindProperty]
        public Notification Notification { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Notification.Add(Notification);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
