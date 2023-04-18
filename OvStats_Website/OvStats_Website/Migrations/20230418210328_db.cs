using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OvStats_Website.Migrations
{
    /// <inheritdoc />
    public partial class db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SummonerAccount",
                columns: table => new
                {
                    accountId = table.Column<string>(type: "text", nullable: false),
                    profileIconId = table.Column<int>(type: "integer", nullable: false),
                    revisionDate = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    id = table.Column<string>(type: "text", nullable: true),
                    puuid = table.Column<string>(type: "text", nullable: true),
                    summonerLevel = table.Column<long>(type: "bigint", nullable: false),
                    region = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummonerAccount", x => x.accountId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SummonerAccount");
        }
    }
}
