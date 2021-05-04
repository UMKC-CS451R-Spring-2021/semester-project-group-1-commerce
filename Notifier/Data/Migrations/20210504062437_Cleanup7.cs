using Microsoft.EntityFrameworkCore.Migrations;

namespace Notifier.Data.Migrations
{
    public partial class Cleanup7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TempRuleCount",
                columns: table => new
                {
                    RuleCountID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RuleType = table.Column<string>(type: "TEXT", nullable: true),
                    TriggeredThisMonth = table.Column<int>(type: "INTEGER", nullable: false),
                    TriggeredThisYear = table.Column<int>(type: "INTEGER", nullable: false),
                    Unread = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempRuleCount", x => x.RuleCountID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TempRuleCount");
        }
    }
}
