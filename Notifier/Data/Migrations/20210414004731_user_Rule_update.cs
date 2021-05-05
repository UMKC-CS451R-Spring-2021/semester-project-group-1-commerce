using Microsoft.EntityFrameworkCore.Migrations;

namespace Notifier.Data.Migrations
{
    public partial class user_Rule_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BeforeAfterDate",
                table: "NotificationRule",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BeforeAfterTime",
                table: "NotificationRule",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MoreLessEqualTrans",
                table: "NotificationRule",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeforeAfterDate",
                table: "NotificationRule");

            migrationBuilder.DropColumn(
                name: "BeforeAfterTime",
                table: "NotificationRule");

            migrationBuilder.DropColumn(
                name: "MoreLessEqualTrans",
                table: "NotificationRule");
        }
    }
}
