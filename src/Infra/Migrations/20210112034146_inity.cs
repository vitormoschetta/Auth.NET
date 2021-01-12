using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class inity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAuth",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "char(44)", maxLength: 44, nullable: false),
                    Salt = table.Column<string>(type: "char(24)", maxLength: 24, nullable: false),
                    Role = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    EmailToken = table.Column<string>(nullable: true),
                    EmailConfirm = table.Column<bool>(nullable: false),
                    ResetPass = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAuth", x => x.Username);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAuth");
        }
    }
}
