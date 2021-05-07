using System;
using Xunit;
using Notifier;
using Notifier.Models;
using Notifier.Pages;
using Notifier.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.Sqlite;
using System.Data.Common;

namespace NotifierTests
{
    public class DashboardTest
    {

        protected IAuthorizationService AuthorizationService { get; }
        protected UserManager<IdentityUser> UserManager { get; }

        private readonly IConfiguration Configuration;

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }

        [Fact]
        public void OnGetUnread()
        {

            var Context = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseSqlite(CreateInMemoryDatabase())
                          .Options;

            //arrange
            var pageModel = new DashboardModel(Context, Configuration, AuthorizationService, UserManager);

            //act
            pageModel.GetUnread();

            //assert
            var Unread = from n in Context.Notification
                         where n.IsRead == false
                         select n;

            var TestUndread = Unread.ToList().Count;

            Assert.Equal(pageModel.UnreadNotifications, TestUndread);
        }

        [Fact]
        public void OnPostExport()
        {
            var Context = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseSqlite(CreateInMemoryDatabase())
                          .Options;

            //arrange
            var UserID = UserManager.GetUserId(User);
            var pageModel = new DashboardModel(Context, Configuration, AuthorizationService, UserManager);

            //assert
            Assert.NotNull(pageModel.OnPostExportAsync());
        }
    }
}
