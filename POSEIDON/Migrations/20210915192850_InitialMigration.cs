using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POSEIDON.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ROL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TABLE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TABLE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Key = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Aditional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destine = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Authorized = table.Column<bool>(type: "bit", nullable: false),
                    Charge = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InternalPhone = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HISTORY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    OriginId = table.Column<int>(type: "int", nullable: false),
                    Activity = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HISTORY", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HISTORY_TABLE_TableId",
                        column: x => x.TableId,
                        principalTable: "TABLE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HISTORY_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USER_ACCESS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    OperativeSystem = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Cyte = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    State = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RefreshDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StillSession = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_ACCESS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USER_ACCESS_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USER_ROL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_ROL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USER_ROL_ROL_RolId",
                        column: x => x.RolId,
                        principalTable: "ROL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USER_ROL_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ROL",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ROOT" },
                    { 2, "ADMIN" },
                    { 3, "USER" }
                });

            migrationBuilder.InsertData(
                table: "USER",
                columns: new[] { "Id", "Account", "Active", "Aditional", "Authorized", "Charge", "Degree", "Destine", "FirstName", "InternalPhone", "Key", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, "ARMADA\\DIAP197", true, "42-04-b1-c7-9a-3f-9c-48-9c-ef-75-04-5a-d0-55-10", true, "PROGRAMADOR", "CP", "DIAP", "DENIS ADRIEL", "122462", "CHAMBI", "CHAMBI", "34-9f-f4-38-5b-c9-40-56-d0-50-80-75-bb-38-e1-8b-ed-27-6d-0b-8d-34-65-38-bf-63-c9-57-9d-de-16-87" },
                    { 2, "ARMADA\\DIAP204", true, "25-ff-57-7d-1d-c4-ba-ca-d2-ac-8d-d5-a5-a0-2a-d3", true, "ENCARGADO SEGUIMIENTO PROFESIONAL", "SM", "DIAP", "JOSE", "122462", "SALINAS", "SALINAS", "5c-73-4d-21-f1-d2-c8-d1-50-50-0b-e3-3a-d8-38-e3-12-b0-1d-d4-3f-4a-45-27-e6-85-13-d8-68-d6-b7-24" },
                    { 3, "ARMADA\\DIAP233", true, "65-d1-9a-4a-7a-0e-c7-aa-54-75-55-ec-cd-a0-dd-cf", true, "AUXILIAR SEGUIMIENTO PROFESIONAL", "CP", "DIAP", "MARIO", "122462", "TOLABA", "TOLABA", "5c-73-4d-21-f1-d2-c8-d1-50-50-0b-e3-3a-d8-38-e3-12-b0-1d-d4-3f-4a-45-27-e6-85-13-d8-68-d6-b7-24" }
                });

            migrationBuilder.InsertData(
                table: "USER_ROL",
                columns: new[] { "Id", "RolId", "UserId" },
                values: new object[] { 3, 1, 1 });

            migrationBuilder.InsertData(
                table: "USER_ROL",
                columns: new[] { "Id", "RolId", "UserId" },
                values: new object[] { 2, 2, 2 });

            migrationBuilder.InsertData(
                table: "USER_ROL",
                columns: new[] { "Id", "RolId", "UserId" },
                values: new object[] { 1, 3, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Activity",
                table: "HISTORY",
                columns: new[] { "Activity", "TableId", "Timestamp" });

            migrationBuilder.CreateIndex(
                name: "IX_ctrUser",
                table: "HISTORY",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_History",
                table: "HISTORY",
                columns: new[] { "TableId", "OriginId", "Activity" });

            migrationBuilder.CreateIndex(
                name: "IX_HistoryTable",
                table: "HISTORY",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "UI_KeyUser",
                table: "USER",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UI_RefreshToken",
                table: "USER_ACCESS",
                column: "RefreshToken",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UI_Token",
                table: "USER_ACCESS",
                columns: new[] { "UserId", "Token" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USER_ROL_RolId",
                table: "USER_ROL",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "UI_UsuarioRol",
                table: "USER_ROL",
                columns: new[] { "UserId", "RolId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HISTORY");

            migrationBuilder.DropTable(
                name: "USER_ACCESS");

            migrationBuilder.DropTable(
                name: "USER_ROL");

            migrationBuilder.DropTable(
                name: "TABLE");

            migrationBuilder.DropTable(
                name: "ROL");

            migrationBuilder.DropTable(
                name: "USER");
        }
    }
}
