using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Notifier.Data.Migrations
{
    public partial class Cleanup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationRule");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotificationRule",
                columns: table => new
                {
                    RuleID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepositWithdrawlFilter = table.Column<int>(type: "INTEGER", nullable: false),
                    DescriptionFilter = table.Column<string>(type: "TEXT", nullable: true),
                    LocationFilter = table.Column<string>(type: "TEXT", nullable: true),
                    MoreLessEqualTrans = table.Column<int>(type: "INTEGER", nullable: false),
                    OwnerID = table.Column<string>(type: "TEXT", nullable: true),
                    TransAmountFilter = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TransactionDateFilter = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TransactionTimeFilter = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationRule", x => x.RuleID);
                });
        }
    }
}
