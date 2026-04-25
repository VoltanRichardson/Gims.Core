using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gims.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SyncModuleSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "GimsModules",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "GimsModules");
        }
    }
}
