using Microsoft.EntityFrameworkCore.Migrations;

namespace Notifier.Data.Migrations
{
    public partial class TimeFix3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Description",
                table: "Description");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Amount",
                table: "Amount");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "LocationRule");

            migrationBuilder.RenameTable(
                name: "Description",
                newName: "DescriptionRule");

            migrationBuilder.RenameTable(
                name: "Amount",
                newName: "AmountRule");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationRule",
                table: "LocationRule",
                column: "LocationRuleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DescriptionRule",
                table: "DescriptionRule",
                column: "DescriptionRuleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AmountRule",
                table: "AmountRule",
                column: "AmountRuleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationRule",
                table: "LocationRule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DescriptionRule",
                table: "DescriptionRule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AmountRule",
                table: "AmountRule");

            migrationBuilder.RenameTable(
                name: "LocationRule",
                newName: "Location");

            migrationBuilder.RenameTable(
                name: "DescriptionRule",
                newName: "Description");

            migrationBuilder.RenameTable(
                name: "AmountRule",
                newName: "Amount");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "LocationRuleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Description",
                table: "Description",
                column: "DescriptionRuleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Amount",
                table: "Amount",
                column: "AmountRuleID");
        }
    }
}
