using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POSEIDON.Migrations
{
    public partial class UsuarioRoles : Migration
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
                    { 1, "ARMADA\\DIAP197", true, "74-52-ce-27-66-ca-0a-7c-51-00-8d-7b-e1-78-d0-ae", true, "PROGRAMADOR", "CP", "DIAP", "DENIS ADRIEL", "122462", "CHAMBI", "CHAMBI", "f7-aa-92-99-41-1e-42-6b-06-6b-60-00-17-bb-b3-7d-60-2b-37-d0-91-4d-db-0c-11-70-13-12-59-64-96-88" },
                    { 2, "ARMADA\\DIAP204", true, "cf-17-d4-ee-b2-23-b3-d6-43-aa-4e-d2-e8-53-f4-cf", true, "ENCARGADO SEGUIMIENTO PROFESIONAL", "SM", "DIAP", "JOSE", "122462", "SALINAS", "SALINAS", "9a-ff-21-83-28-cd-22-6c-27-4b-2d-dd-6c-c9-85-29-9a-e0-64-08-e3-7e-af-a2-91-bf-fb-89-72-b4-7c-ac" },
                    { 3, "ARMADA\\DIAP233", true, "d3-7a-d4-f5-f3-a4-f5-a0-8f-43-54-41-83-9b-b3-a2", true, "AUXILIAR SEGUIMIENTO PROFESIONAL", "CP", "DIAP", "MARIO", "122462", "TOLABA", "TOLABA", "20-2d-f1-5b-03-76-7d-41-93-86-be-89-63-22-49-ae-9a-49-19-3c-4e-e0-7a-71-9a-3a-a1-15-a3-e7-2c-49" }
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
