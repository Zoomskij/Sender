using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SenderApp.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsStarted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    IsSended = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Configs",
                columns: new[] { "Id", "CreatedDate", "IsStarted", "ModifiedDate" },
                values: new object[] { new Guid("ce7bf1f7-b998-4aff-b506-c0951dcea692"), new DateTime(2022, 3, 11, 18, 56, 5, 454, DateTimeKind.Utc).AddTicks(9485), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "IsSended", "ModifiedDate", "Name" },
                values: new object[] { new Guid("050122a1-61bf-41f6-b7df-0b41659f374d"), "Zoomskij@gmail.com", new DateTime(2022, 3, 11, 18, 56, 5, 456, DateTimeKind.Utc).AddTicks(7795), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "My" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configs");

            migrationBuilder.DropTable(
                name: "Emails");
        }
    }
}
