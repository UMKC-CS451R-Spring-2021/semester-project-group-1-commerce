using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Notifier.Data.Migrations
{
    public partial class NotificationType6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeforeAfterTime",
                table: "TimeRule");

            migrationBuilder.DropColumn(
                name: "BeforeAfterDate",
                table: "NotificationRule");

            migrationBuilder.DropColumn(
                name: "BeforeAfterTime",
                table: "NotificationRule");

            migrationBuilder.RenameColumn(
                name: "TransactionTimeFilter",
                table: "TimeRule",
                newName: "TransactionTimeFilterUntil");

            migrationBuilder.AddColumn<DateTime>(
                name: "TransactionTimeFilterFrom",
                table: "TimeRule",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionTimeFilterFrom",
                table: "TimeRule");

            migrationBuilder.RenameColumn(
                name: "TransactionTimeFilterUntil",
                table: "TimeRule",
                newName: "TransactionTimeFilter");

            migrationBuilder.AddColumn<int>(
                name: "BeforeAfterTime",
                table: "TimeRule",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BeforeAfterDate",
                table: "NotificationRule",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BeforeAfterTime",
                table: "NotificationRule",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
