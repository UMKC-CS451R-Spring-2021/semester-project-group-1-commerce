using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Notifier.Data.Migrations
{
    public partial class user_Rule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotificationRule",
                columns: table => new
                {
                    RuleID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OwnerID = table.Column<string>(type: "TEXT", nullable: true),
                    TransactionDateFilter = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TransactionTimeFilter = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LocationFilter = table.Column<string>(type: "TEXT", nullable: true),
                    DepositWithdrawlFilter = table.Column<string>(type: "TEXT", nullable: true),
                    TransAmountFilter = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DescriptionFilter = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationRule", x => x.RuleID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationRule");
        }
    }
}
