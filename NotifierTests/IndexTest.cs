using System;
using Xunit;
using Notifier;
using Notifier.Models;
using Notifier.Pages;
using Notifier.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Notifier.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System.Data.Common;

namespace NotifierTests
{
    public class IndexTest
    {

        protected IAuthorizationService AuthorizationService { get; }
        protected UserManager<IdentityUser> UserManager { get; }

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }

        [Fact]
        public void OnGet_IfFirstTime_Redirect()
        {
            const string userName = "TestUser";

            var Context = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseSqlite(CreateInMemoryDatabase())
                          .Options;

            IdentityUser user = new IdentityUser(userName);
            UserManager.CreateAsync(user);

            //arrange
            var pageModel = new IndexModel(Context, AuthorizationService, UserManager);

            //act
            var result = pageModel.OnGet();

            //assert
            RedirectToPageResult redirect = result as RedirectToPageResult; //<--cast here
            Assert.Equal("/Account/Balance/Create", redirect.PageName);
        }

        [Fact]
        public void OnGet_AlreadyInitialzed_Redirect()
        {
            const string userName = "TestUser";

            var Context = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseSqlite(CreateInMemoryDatabase())
                          .Options;

            IdentityUser user = new IdentityUser(userName);
            UserManager.CreateAsync(user);



            var tempBalance = new BalanceModel { BalanceAmount = 2000, OwnerID = UserID, OwnerName = "Test" };
            Context.BalanceModel.Add(tempBalance);

            //arrange
            var pageModel = new IndexModel(Context, AuthorizationService, UserManager);

            //act
            var result = pageModel.OnGet();

            //assert
            RedirectToPageResult redirect = result as RedirectToPageResult; //<--cast here
            Assert.Equal("/Dashbaord", redirect.PageName);
        }

        [Fact]
        public void NotLoggedIn()
        {
            var Context = new DbContextOptionsBuilder<ApplicationDbContext>()
                         .UseSqlite(CreateInMemoryDatabase())
                         .Options;

            var pageModel = new IndexModel(Context, AuthorizationService, UserManager);
            Assert.NotNull(pageModel.OnGet());
        }
    }
}
