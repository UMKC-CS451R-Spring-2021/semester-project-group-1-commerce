using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notifier.Models;

    public class NotifierTransactionContext : DbContext
    {
        public NotifierTransactionContext (DbContextOptions<NotifierTransactionContext> options)
            : base(options)
        {
        }

        public DbSet<Notifier.Models.Transaction> Transaction { get; set; }
    }
