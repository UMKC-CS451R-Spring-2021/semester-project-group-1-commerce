using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Notifier.Models;

namespace Notifier.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Notifier.Models.Transaction> Transaction { get; set; }
        public DbSet<Notifier.Models.AmountRule> AmountRule { get; set; }
        public DbSet<Notifier.Models.TimeRule> TimeRule { get; set; }
        public DbSet<Notifier.Models.LocationRule> LocationRule { get; set; }
        public DbSet<Notifier.Models.DescriptionRule> DescriptionRule { get; set; }
        public DbSet<Notifier.Models.MiscRule> MiscRule { get; set; }
        public DbSet<Notifier.Models.Notification> Notification { get; set; }
        public DbSet<Notifier.Models.BalanceModel> BalanceModel { get; set; }
    }
}
