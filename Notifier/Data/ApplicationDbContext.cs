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
        public DbSet<Notifier.Models.NotificationRule> NotificationRule { get; set; }
        public DbSet<Notifier.Models.Amount> Amount { get; set; }
        public DbSet<Notifier.Models.Time> Time { get; set; }
        public DbSet<Notifier.Models.Location> Location { get; set; }
        public DbSet<Notifier.Models.Description> Description { get; set; }
    }
}
