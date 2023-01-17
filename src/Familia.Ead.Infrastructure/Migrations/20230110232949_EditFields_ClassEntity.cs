using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Familia.Ead.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditFieldsClassEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VideoUri",
                table: "Classes",
                newName: "Video");

            migrationBuilder.AddColumn<string>(
                name: "Thumb",
                table: "Classes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Thumb",
                table: "Classes");

            migrationBuilder.RenameColumn(
                name: "Video",
                table: "Classes",
                newName: "VideoUri");
        }
    }
}
