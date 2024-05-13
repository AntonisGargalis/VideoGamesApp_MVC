using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VideoGames.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addProductsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Price", "Publisher", "SerialNumber", "Title" },
                values: new object[,]
                {
                    { 1, "Survival in a post apocaliptic world", 39.899999999999999, "Bethesda Studios", "345-F54-O11", "Fallout 4" },
                    { 2, "Action first person shooting", 59.899999999999999, "ACTIVITION", "367-C14-D45", "Call of Duty Modern Warfare" },
                    { 3, "Medival world with nights and wizards", 29.899999999999999, "CD Project", "876-T23-W19", "The Witcher 3" },
                    { 4, "RPG MMO viking game", 24.899999999999999, "Bethesda Studios", "E45-S94-S41", "Elder Scrolls Skyrim" },
                    { 5, "Greek hellenic 300bc", 49.899999999999999, "Ubisoft", "A85-C14-O77", "Assassin Creed Odyssey" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
