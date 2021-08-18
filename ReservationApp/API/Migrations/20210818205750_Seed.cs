using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Floors",
                columns: new[] { "Id", "Name", "Number" },
                values: new object[,]
                {
                    { 1, "Parter", 0 },
                    { 2, "Piętro 1", 1 },
                    { 3, "Piętro 2", 2 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "User" },
                    { 2, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Description", "FloorId", "Name", "Number" },
                values: new object[,]
                {
                    { 1, "Tylko dla portierki", 1, "Portiernia", 1 },
                    { 2, "Do pracy", 2, "Pokój komputerowy", 101 },
                    { 3, "Do konferencji", 2, "Sala konferencyjna", 102 },
                    { 4, "Tylko dla informatyków", 3, "Serwerownia", 201 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "RoleId", "UserName" },
                values: new object[,]
                {
                    { 1, null, "Ędward", "Ącki", "qaz123", 1, "logged_user" },
                    { 2, null, "Karol", "Kulesza", "qaz123", 2, "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Description", "Name", "RoomId" },
                values: new object[,]
                {
                    { 1, null, "Fotel", 1 },
                    { 2, null, "Krzesło 1", 2 },
                    { 3, null, "Krzesło 2", 2 },
                    { 4, null, "Taboret 1", 3 },
                    { 5, null, "Taboret 2", 3 },
                    { 6, null, "Pufa", 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
