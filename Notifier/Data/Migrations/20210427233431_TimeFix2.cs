using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Notifier.Data.Migrations
{
    public partial class TimeFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Time");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Description",
                newName: "descriptionNotification");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "Amount",
                newName: "amountNotification");

            migrationBuilder.CreateTable(
                name: "TimeRule",
                columns: table => new
                {
                    TimeRuleID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OwnerID = table.Column<string>(type: "TEXT", nullable: true),
                    BeforeAfterTime = table.Column<int>(type: "INTEGER", nullable: false),
                    TransactionTimeFilter = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeRule", x => x.TimeRuleID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeRule");

            migrationBuilder.RenameColumn(
                name: "descriptionNotification",
                table: "Description",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "amountNotification",
                table: "Amount",
                newName: "amount");

            migrationBuilder.CreateTable(
                name: "Time",
                columns: table => new
                {
                    TimeRuleID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BeforeAfterTime = table.Column<int>(type: "INTEGER", nullable: false),
                    OwnerID = table.Column<string>(type: "TEXT", nullable: true),
                    TransactionTimeFilter = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Time", x => x.TimeRuleID);
                });
        }
    }
}
