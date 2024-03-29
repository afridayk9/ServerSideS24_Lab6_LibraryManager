using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab6_LibraryManager.Migrations
{
    /// <inheritdoc />
    public partial class addedfk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CheckedOutBy",
                table: "Books",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckedOutBy",
                table: "Books");
        }
    }
}
