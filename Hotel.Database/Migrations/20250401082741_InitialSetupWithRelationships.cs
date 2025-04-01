using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hotel.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetupWithRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Availability = table.Column<int>(type: "int", nullable: false),
                    RoomNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Workers_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "ID", "RoomNumber", "Status" },
                values: new object[,]
                {
                    { 1, "101", 1 },
                    { 2, "102", 0 },
                    { 3, "103", 2 },
                    { 4, "104", 0 },
                    { 5, "105", 1 },
                    { 6, "106", 1 },
                    { 7, "107", 1 },
                    { 8, "108", 1 },
                    { 9, "109", 1 },
                    { 10, "110", 1 },
                    { 11, "111", 1 },
                    { 12, "112", 1 }
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "ID", "Availability", "Name", "RoomId", "RoomNumber" },
                values: new object[,]
                {
                    { 1, 0, "Jone", 1, "101" },
                    { 2, 2, "Sarah Jonshon", 2, "102" },
                    { 3, 1, "Emily", 3, "103" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_RoomId",
                table: "Workers",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
