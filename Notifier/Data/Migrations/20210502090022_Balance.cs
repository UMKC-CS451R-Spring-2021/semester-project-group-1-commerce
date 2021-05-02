using Microsoft.EntityFrameworkCore.Migrations;

namespace Notifier.Data.Migrations
{
    public partial class Balance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "amountNotification",
                table: "AmountRule",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateTable(
                name: "Balance",
                columns: table => new
                {
                    BalanceID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OwnerID = table.Column<string>(type: "TEXT", nullable: true),
                    BalanceAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    OwnerName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balance", x => x.BalanceID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balance");

            migrationBuilder.AlterColumn<int>(
                name: "amountNotification",
                table: "AmountRule",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "decimal(18, 2)");
        }
    }
}
