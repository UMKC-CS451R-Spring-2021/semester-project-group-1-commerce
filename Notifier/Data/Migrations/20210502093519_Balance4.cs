using Microsoft.EntityFrameworkCore.Migrations;

namespace Notifier.Data.Migrations
{
    public partial class Balance4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Balance",
                table: "Balance");

            migrationBuilder.RenameTable(
                name: "Balance",
                newName: "BalanceModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BalanceModel",
                table: "BalanceModel",
                column: "BalanceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BalanceModel",
                table: "BalanceModel");

            migrationBuilder.RenameTable(
                name: "BalanceModel",
                newName: "Balance");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Balance",
                table: "Balance",
                column: "BalanceID");
        }
    }
}
