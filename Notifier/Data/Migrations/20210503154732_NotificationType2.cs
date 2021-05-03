using Microsoft.EntityFrameworkCore.Migrations;

namespace Notifier.Data.Migrations
{
    public partial class NotificationType2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MiscRule",
                columns: table => new
                {
                    MiscRuleID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OwnerID = table.Column<string>(type: "TEXT", nullable: true),
                    wantOverdraft = table.Column<bool>(type: "INTEGER", nullable: false),
                    wantAllDeposit = table.Column<bool>(type: "INTEGER", nullable: false),
                    wantAllWithdraw = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiscRule", x => x.MiscRuleID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MiscRule");
        }
    }
}
