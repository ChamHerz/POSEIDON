using Microsoft.EntityFrameworkCore.Migrations;

namespace POSEIDON.Migrations
{
    public partial class CreacionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    Account = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Destine = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Authorized = table.Column<bool>(type: "bit", nullable: false),
                    Charge = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InternalPhone = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.Account);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USER");
        }
    }
}
