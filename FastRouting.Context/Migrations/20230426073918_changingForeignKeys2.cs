using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastRouting.Context.Migrations
{
    /// <inheritdoc />
    public partial class changingForeignKeys2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intersections_Coordinate_Coordinateid",
                table: "Intersections");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Coordinate_coordinateid",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "IntersectionID",
                table: "TransitionsToIntersections",
                newName: "intersectionId");

            migrationBuilder.RenameColumn(
                name: "TransitionId",
                table: "TransitionsToIntersections",
                newName: "transitionId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Transitions",
                newName: "trasitionId");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "TheCenterPhoto",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TheCenterPhoto",
                newName: "theMallPhotoId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Centers",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Centers",
                newName: "shoppingMallId");

            migrationBuilder.RenameColumn(
                name: "coordinateid",
                table: "Locations",
                newName: "coordinateId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Locations",
                newName: "locationId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_coordinateid",
                table: "Locations",
                newName: "IX_Locations_coordinateId");

            migrationBuilder.RenameColumn(
                name: "Coordinateid",
                table: "Intersections",
                newName: "coordinateId");

            migrationBuilder.RenameColumn(
                name: "IntersectionID",
                table: "Intersections",
                newName: "intersectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Intersections_Coordinateid",
                table: "Intersections",
                newName: "IX_Intersections_coordinateId");

            migrationBuilder.RenameColumn(
                name: "Distance",
                table: "Edges",
                newName: "distance");

            migrationBuilder.RenameColumn(
                name: "LocationIdB",
                table: "Edges",
                newName: "locationIdB");

            migrationBuilder.RenameColumn(
                name: "LocationIdA",
                table: "Edges",
                newName: "locationIdA");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Coordinate",
                newName: "coordinateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Intersections_Coordinate_coordinateId",
                table: "Intersections",
                column: "coordinateId",
                principalTable: "Coordinate",
                principalColumn: "coordinateId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Coordinate_coordinateId",
                table: "Locations",
                column: "coordinateId",
                principalTable: "Coordinate",
                principalColumn: "coordinateId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intersections_Coordinate_coordinateId",
                table: "Intersections");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Coordinate_coordinateId",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "intersectionId",
                table: "TransitionsToIntersections",
                newName: "IntersectionID");

            migrationBuilder.RenameColumn(
                name: "transitionId",
                table: "TransitionsToIntersections",
                newName: "TransitionId");

            migrationBuilder.RenameColumn(
                name: "trasitionId",
                table: "Transitions",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "TheCenterPhoto",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "theMallPhotoId",
                table: "TheCenterPhoto",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Centers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "shoppingMallId",
                table: "Centers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "coordinateId",
                table: "Locations",
                newName: "coordinateid");

            migrationBuilder.RenameColumn(
                name: "locationId",
                table: "Locations",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_coordinateId",
                table: "Locations",
                newName: "IX_Locations_coordinateid");

            migrationBuilder.RenameColumn(
                name: "coordinateId",
                table: "Intersections",
                newName: "Coordinateid");

            migrationBuilder.RenameColumn(
                name: "intersectionId",
                table: "Intersections",
                newName: "IntersectionID");

            migrationBuilder.RenameIndex(
                name: "IX_Intersections_coordinateId",
                table: "Intersections",
                newName: "IX_Intersections_Coordinateid");

            migrationBuilder.RenameColumn(
                name: "distance",
                table: "Edges",
                newName: "Distance");

            migrationBuilder.RenameColumn(
                name: "locationIdB",
                table: "Edges",
                newName: "LocationIdB");

            migrationBuilder.RenameColumn(
                name: "locationIdA",
                table: "Edges",
                newName: "LocationIdA");

            migrationBuilder.RenameColumn(
                name: "coordinateId",
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
        }
    }
}
