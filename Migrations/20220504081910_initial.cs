using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactManagerAPP.V2.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Organization = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contacts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Family" },
                    { 2, "Friend" },
                    { 3, "Work" },
                    { 4, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "CategoryId", "DateAdded", "Email", "FirstName", "LastName", "Organization", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 5, 4, 4, 19, 9, 706, DateTimeKind.Local).AddTicks(2244), "MBear@outlook.com", "Momma", "Bear", null, "555-555-5555" },
                    { 2, 2, new DateTime(2022, 5, 4, 4, 19, 9, 710, DateTimeKind.Local).AddTicks(3595), "Bboy@aol.com", "Buddy", "Boy", null, "555-555-1234" },
                    { 3, 3, new DateTime(2022, 5, 4, 4, 19, 9, 710, DateTimeKind.Local).AddTicks(3652), "BigBoss@yahoo.com", "Boss", "Man", null, "555-555-1050" },
                    { 4, 4, new DateTime(2022, 5, 4, 4, 19, 9, 710, DateTimeKind.Local).AddTicks(3659), "danger@hotmail.com", "Stranger", "Danger", null, "555-555-1452" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CategoryId",
                table: "Contacts",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
