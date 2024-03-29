﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notifier.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Notifier.Data;
using System;

namespace Notifier.Pages.Transactions
{
    public class FilteredTransactionsModel : PagesTransactions.DI_BasePageModel
    {
        //private readonly ApplicationDbContext _context;

        public FilteredTransactionsModel(
        ApplicationDbContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        public IList<Transaction> Transaction { get;set; }

        public IList<Transaction> FilteredList { get; set; }

        public IList<Notification> notificaionsGotten { get; set; }

        public async Task OnGetAsync()
        {

            var currentUserId = UserManager.GetUserId(User);
            DateTime currentTime = DateTime.Now;

            var amountTransactions = from t in Context.Transaction
                                     from r in Context.AmountRule
                                     where (r.GreaterLess == (NumComparator)1 && t.TransAmount > r.amountNotification)
                                     || (r.GreaterLess == (NumComparator)2 && t.TransAmount < r.amountNotification)
                                     || (r.GreaterLess == (NumComparator)3 && t.TransAmount == r.amountNotification)
                                     && t.OwnerID == currentUserId
                                     select t;

            Transaction = await amountTransactions.ToListAsync();
        }
    }
}
