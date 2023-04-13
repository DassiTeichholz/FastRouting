using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastRouting.Context.Migrations
{
    /// <inheritdoc />
    public partial class changedthedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intersections_Coordinate_CoordinateId",
                table: "Intersections");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Coordinate_CoordinateId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_LocationTypes_LocationTypesId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Transitions_TransitionId",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "TransitionsName",
                table: "Transitions",
                newName: "transitionsName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Transitions",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TransitionId",
                table: "Locations",
                newName: "transitionId");

            migrationBuilder.RenameColumn(
                name: "LocationTypesId",
                table: "Locations",
                newName: "locationTypesId");

            migrationBuilder.RenameColumn(
                name: "LocationName",
                table: "Locations",
                newName: "locationName");

            migrationBuilder.RenameColumn(
                name: "CoordinateId",
                table: "Locations",
                newName: "coordinateid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Locations",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_TransitionId",
                table: "Locations",
                newName: "IX_Locations_transitionId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_LocationTypesId",
                table: "Locations",
                newName: "IX_Locations_locationTypesId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_CoordinateId",
                table: "Locations",
                newName: "IX_Locations_coordinateid");

            migrationBuilder.RenameColumn(
                name: "CoordinateId",
                table: "Intersections",
                newName: "Coordinateid");

            migrationBuilder.RenameIndex(
                name: "IX_Intersections_CoordinateId",
                table: "Intersections",
                newName: "IX_Intersections_Coordinateid");

            migrationBuilder.RenameColumn(
                name: "Z",
                table: "Coordinate",
                newName: "z");

            migrationBuilder.RenameColumn(
                name: "Y",
                table: "Coordinate",
                newName: "y");

            migrationBuilder.RenameColumn(
                name: "X",
                table: "Coordinate",
                newName: "x");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Coordinate",
                newName: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Intersections_Coordinate_Coordinateid",
                table: "Intersections",
                column: "Coordinateid",
                principalTable: "Coordinate",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Coordinate_coordinateid",
                table: "Locations",
                column: "coordinateid",
                principalTable: "Coordinate",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_LocationTypes_locationTypesId",
                table: "Locations",
                column: "locationTypesId",
                principalTable: "LocationTypes",
                principalColumn: "locationTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Transitions_transitionId",
                table: "Locations",
                column: "transitionId",
                principalTable: "Transitions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intersections_Coordinate_Coordinateid",
                table: "Intersections");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Coordinate_coordinateid",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_LocationTypes_locationTypesId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Transitions_transitionId",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "transitionsName",
                table: "Transitions",
                newName: "TransitionsName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Transitions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "transitionId",
                table: "Locations",
                newName: "TransitionId");

            migrationBuilder.RenameColumn(
                name: "locationTypesId",
                table: "Locations",
                newName: "LocationTypesId");

            migrationBuilder.RenameColumn(
                name: "locationName",
                table: "Locations",
                newName: "LocationName");

            migrationBuilder.RenameColumn(
                name: "coordinateid",
                table: "Locations",
                newName: "CoordinateId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Locations",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_transitionId",
                table: "Locations",
                newName: "IX_Locations_TransitionId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_locationTypesId",
                table: "Locations",
                newName: "IX_Locations_LocationTypesId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_coordinateid",
                table: "Locations",
                newName: "IX_Locations_CoordinateId");

            migrationBuilder.RenameColumn(
                name: "Coordinateid",
                table: "Intersections",
                newName: "CoordinateId");

            migrationBuilder.RenameIndex(
                name: "IX_Intersections_Coordinateid",
                table: "Intersections",
                newName: "IX_Intersections_CoordinateId");

            migrationBuilder.RenameColumn(
                name: "z",
                table: "Coordinate",
                newName: "Z");

            migrationBuilder.RenameColumn(
                name: "y",
                table: "Coordinate",
                newName: "Y");

            migrationBuilder.RenameColumn(
                name: "x",
                table: "Coordinate",
                newName: "X");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Coordinate",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Intersections_Coordinate_CoordinateId",
                table: "Intersections",
                column: "CoordinateId",
                principalTable: "Coordinate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Coordinate_CoordinateId",
                table: "Locations",
                column: "CoordinateId",
                principalTable: "Coordinate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_LocationTypes_LocationTypesId",
                table: "Locations",
                column: "LocationTypesId",
                principalTable: "LocationTypes",
                principalColumn: "locationTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Transitions_TransitionId",
                table: "Locations",
                column: "TransitionId",
                principalTable: "Transitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
