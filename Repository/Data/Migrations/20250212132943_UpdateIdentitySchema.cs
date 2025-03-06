using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eFilm.Migrations
{
    public partial class UpdateIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginVM");

            migrationBuilder.DropTable(
                name: "RegisterVM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginVM",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginVM", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "RegisterVM",
                columns: table => new
                {
                    FullName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterVM", x => x.FullName);
                });
        }
    }
}
