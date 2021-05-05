using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Notifier.Data;
using Notifier.Models;

namespace Notifier.Controllers
{
    public class NotificationRulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotificationRulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NotificationRules
        public async Task<IActionResult> Index()
        {
            return View(await _context.NotificationRule.ToListAsync());
        }

        // GET: NotificationRules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notificationRule = await _context.NotificationRule
                .FirstOrDefaultAsync(m => m.RuleID == id);
            if (notificationRule == null)
            {
                return NotFound();
            }

            return View(notificationRule);
        }

        // GET: NotificationRules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NotificationRules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RuleID,OwnerID,BeforeAfterDate,TransactionDateFilter,BeforeAfterTime,TransactionTimeFilter,LocationFilter,DepositWithdrawlFilter,MoreLessEqualTrans,TransAmountFilter,DescriptionFilter")] NotificationRule notificationRule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notificationRule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notificationRule);
        }

        // GET: NotificationRules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notificationRule = await _context.NotificationRule.FindAsync(id);
            if (notificationRule == null)
            {
                return NotFound();
            }
            return View(notificationRule);
        }

        // POST: NotificationRules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RuleID,OwnerID,BeforeAfterDate,TransactionDateFilter,BeforeAfterTime,TransactionTimeFilter,LocationFilter,DepositWithdrawlFilter,MoreLessEqualTrans,TransAmountFilter,DescriptionFilter")] NotificationRule notificationRule)
        {
            if (id != notificationRule.RuleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notificationRule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificationRuleExists(notificationRule.RuleID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(notificationRule);
        }

        // GET: NotificationRules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notificationRule = await _context.NotificationRule
                .FirstOrDefaultAsync(m => m.RuleID == id);
            if (notificationRule == null)
            {
                return NotFound();
            }

            return View(notificationRule);
        }

        // POST: NotificationRules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notificationRule = await _context.NotificationRule.FindAsync(id);
            _context.NotificationRule.Remove(notificationRule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotificationRuleExists(int id)
        {
            return _context.NotificationRule.Any(e => e.RuleID == id);
        }
    }
}
