using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrintLayer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Data = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Grade = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VotePrints",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ImageId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Votes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotePrints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VotePrints_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VotePrints_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "77b6d946-a38c-44d7-8043-b365c65bcc92", 0, "f70c9109-9130-4a5b-822f-0fa261d27558", "admin", true, false, null, null, null, "a322b9c0b8e19ef16d4d308cd4e1222106d0edf8fbb3c8f1649242dff54a740c", null, false, "e32447ab-73f3-4f03-bd01-b89837c89366", false, "Admin Admin" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "CreatedDate", "Description", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("44b05f8a-fb35-4b64-b0d3-850cdc07e76a"), new DateTime(2022, 3, 5, 13, 51, 31, 298, DateTimeKind.Utc).AddTicks(6446), "This is a test news description 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Test Name 1" },
                    { new Guid("7031be1f-8c8c-4ec7-98c8-ae24d7eeced6"), new DateTime(2022, 3, 5, 13, 51, 31, 298, DateTimeKind.Utc).AddTicks(7079), "This is a test news description 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Test Name 2" },
                    { new Guid("b1f2931b-e49a-440e-8ee6-9dcccb854694"), new DateTime(2022, 3, 5, 13, 51, 31, 298, DateTimeKind.Utc).AddTicks(7127), "This is a test news description 3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Test Name 3" },
                    { new Guid("8fc8a257-1c57-442c-bb2a-901a03b87ced"), new DateTime(2022, 3, 5, 13, 51, 31, 298, DateTimeKind.Utc).AddTicks(7148), "This is a test news description 4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Test Name 4" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "CreatedDate", "Description", "ModifiedDate", "Phone", "Status", "UserId" },
                values: new object[,]
                {
                    { new Guid("3403ad77-2007-4184-a243-64e37e607f31"), "Moscow Kremlin st 0", new DateTime(2022, 3, 5, 13, 51, 31, 297, DateTimeKind.Utc).AddTicks(7873), "Sample Description 0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+71234567890", 1, "77b6d946-a38c-44d7-8043-b365c65bcc92" },
                    { new Guid("a104d94e-f760-44c5-966e-bf26fc3c44ce"), "Moscow Kremlin st 19", new DateTime(2022, 3, 5, 13, 51, 31, 297, DateTimeKind.Utc).AddTicks(9871), "Sample Description 19", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+71234567890", 1, "77b6d946-a38c-44d7-8043-b365c65bcc92" },
                    { new Guid("f45e3161-b8d4-462a-a929-126b8c62e7c6"), "Moscow Kremlin st 18", new DateTime(2022, 3, 5, 13, 51, 31, 297, DateTimeKind.Utc).AddTicks(9851), "Sample Description 18", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+71234567890", 1, "77b6d946-a38c-44d7-8043-b365c65bcc92" },
                    { new Guid("23fa048c-cb12-497f-bd75-3d62c4563801"), "Moscow Kremlin st 17", new DateTime(2022, 3, 5, 13, 51, 31, 297, DateTimeKind.Utc).AddTicks(9831), "Sample Description 17", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+71234567890", 1, "77b6d946-a38c-44d7-8043-b365c65bcc92" },
                    { new Guid("9f5abb79-8ac1-4416-83d1-08385df87b52"), "Moscow Kremlin st 16", new DateTime(2022, 3, 5, 13, 51, 31, 297, DateTimeKind.Utc).AddTicks(9809), "Sample Description 16", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+71234567890", 1, "77b6d946-a38c-44d7-8043-b365c65bcc92" },
                    { new Guid("1ed56b1d-2ec5-4763-8736-cb0debeecd9b"), "Moscow Kremlin st 15", new DateTime(2022, 3, 5, 13, 51, 31, 297, DateTimeKind.Utc).AddTicks(9789), "Sample Description 15", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+71234567890", 1, "77b6d946-a38c-44d7-8043-b365c65bcc92" },
                    { new Guid("df31e67b-8745-4a94-9015-c639724d2d5d"), "Moscow Kremlin st 14", new DateTime(2022, 3, 5, 13, 51, 31, 297, DateTimeKind.Utc).AddTicks(9769), "Sample Description 14", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+71234567890", 1, "77b6d946-a38c-44d7-8043-b365c65bcc92" },
                    { new Guid("abc02c44-a54d-410b-992a-163d957f9641"), "Moscow Kremlin st 13", new DateTime(2022, 3, 5, 13, 51, 31, 297, DateTimeKind.Utc).AddTicks(9749), "Sample Description 13", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+71234567890", 1, "77b6d946-a38c-44d7-8043-b365c65bcc92" },
                    { new Guid("6e30abe9-3e84-4a74-b012-3d02e10379c1"), "Moscow Kremlin st 12", new DateTime(2022, 3, 5, 13, 51, 31, 297, DateTimeKind.Utc).AddTicks(9727), "Sample Description 12", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+71234567890", 1, "77b6d946-a38c-44d7-8043-b365c65bcc92" },
                    { new Guid("59de5e72-c199-4fe1-8192-1516b7382ae1"), "Moscow Kremlin st 10", new DateTime(2022, 3, 5, 13, 51, 31, 297, DateTimeKind.Utc).AddTicks(9686), "Sample Description 10", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+71234567890", 1, "77b6d946-a38c-44d7-8043-b365c65bcc92" },
                    { new Guid("1d55de0a-4ab0-42f4-bd2a-a697833b0a07"), "Moscow Kremlin st 11", new DateTime(2022, 3, 5, 13, 51, 31, 297, DateTimeKind.Utc).AddTicks(9707), "Sample Description 11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+71234567890", 1, "77b6d946-a38c-44d7-8043-b365c65bcc92" },
                    { new Guid("68276b69-ff68-4687-a8a0-39b174b038de"), "Moscow Kremlin st 8", new DateTime(2022, 3, 5, 13, 51, 31, 297, DateTimeKind.Utc).AddTicks(9605), "Sample Description 8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+71234567890", 1, "77b6d946-a38c-44d7-8043-b365c65bcc92" },
                    { new Guid("25d5f17c-da3d-4e58-80cc-91b7ec201a8b"), "Moscow Kremlin st 7", new DateTime(2022, 3, 5, 13, 51, 31, 297, DateTimeKind.Utc).AddTicks(9585), "Sample Description 7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+71234567890", 1, "77b6d946-a38c-44d7-8043-b365c65bcc92" },
                    { new Guid("06c7d58a-cfc2-4d67-9281-7f2467e519d7"), "Moscow Kremlin st 6", new DateTime(2022, 3, 5, 13, 51, 31, 297, DateTimeKind.Utc).AddTicks(9564), "Sample Description 6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+71234567890", 1, "77b6d946-a38c-44d7-8043-b365c65bcc92" },
                    { new Guid("f66cfac0-a224-4fe9-9939-59652763af3e"), "Moscow Kremlin st 5", new DateTime(2022, 3, 5, 13, 51, 31, 297, DateTimeKind.Utc).AddTicks(9543), "Sample Description 5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+71234567890", 1, "77b6d946-a38c-44d7-8043-b365c65bcc92" },
                    { new Guid("0b73eda5-2ad4-4776-8679-e1bfeafe0ad0"), "Moscow Kremlin st 4", new DateTime(2022, 3, 5, 13, 51, 31, 297, DateTimeKind.Utc).AddTicks(9515), "Sample Description 4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+71234567890", 1, "77b6d946-a38c-44d7-8043-b365c65bcc92" },
                    { new Guid("2041a8aa-142d-4137-abe5-55e44ce524e6"), "Moscow Kremlin st 3", new DateTime(2022, 3, 5, 13, 51, 31, 297, DateTimeKind.Utc).AddTicks(9493), "Sample Description 3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+71234567890", 1, "77b6d946-a38c-44d7-8043-b365c65bcc92" },
                    { new Guid("2c02bc4b-926e-4bba-b678-7da6dca364ed"), "Moscow Kremlin st 2", new DateTime(2022, 3, 5, 13, 51, 31, 297, DateTimeKind.Utc).AddTicks(9467), "Sample Description 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+71234567890", 1, "77b6d946-a38c-44d7-8043-b365c65bcc92" },
                    { new Guid("0a55d8c5-10bf-4b46-8f49-bedd9dbdcbb2"), "Moscow Kremlin st 1", new DateTime(2022, 3, 5, 13, 51, 31, 297, DateTimeKind.Utc).AddTicks(9387), "Sample Description 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+71234567890", 1, "77b6d946-a38c-44d7-8043-b365c65bcc92" },
                    { new Guid("c51bdb56-5433-4680-82f5-18a5a0c3a253"), "Moscow Kremlin st 9", new DateTime(2022, 3, 5, 13, 51, 31, 297, DateTimeKind.Utc).AddTicks(9662), "Sample Description 9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+71234567890", 1, "77b6d946-a38c-44d7-8043-b365c65bcc92" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CreatedDate", "Description", "Grade", "ModifiedDate", "UserId", "UserName" },
                values: new object[,]
                {
                    { new Guid("69877762-9942-464e-a1eb-6e6b7123c8eb"), new DateTime(2022, 3, 5, 13, 51, 31, 298, DateTimeKind.Utc).AddTicks(3769), "Sample review Description 3", (byte)3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "77b6d946-a38c-44d7-8043-b365c65bcc92", "Admin Admin" },
                    { new Guid("97418bb2-1365-4de4-ad55-2ca40e0fbc36"), new DateTime(2022, 3, 5, 13, 51, 31, 298, DateTimeKind.Utc).AddTicks(2445), "Sample review Description 1", (byte)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "77b6d946-a38c-44d7-8043-b365c65bcc92", "Admin Admin" },
                    { new Guid("aa4e55ac-bd36-45f1-acea-8da13292bccf"), new DateTime(2022, 3, 5, 13, 51, 31, 298, DateTimeKind.Utc).AddTicks(3652), "Sample review Description 2", (byte)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "77b6d946-a38c-44d7-8043-b365c65bcc92", "Admin Admin" },
                    { new Guid("3ed3eab0-819e-42fd-b11a-b8d6721a5f9d"), new DateTime(2022, 3, 5, 13, 51, 31, 298, DateTimeKind.Utc).AddTicks(3795), "Sample review Description 4", (byte)4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "77b6d946-a38c-44d7-8043-b365c65bcc92", "Admin Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VotePrints_ImageId",
                table: "VotePrints",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_VotePrints_UserId",
                table: "VotePrints",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "VotePrints");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
