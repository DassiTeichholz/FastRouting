using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastRouting.Context.Migrations
{
    /// <inheritdoc />
    public partial class IntersectionOnLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IntersectionOnLocation",
                table: "Intersections",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IntersectionOnLocation",
                table: "Intersections");
        }
    }
}
