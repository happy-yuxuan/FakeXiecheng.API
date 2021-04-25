using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeXiecheng.API.Migrations
{
    public partial class ModifyTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourisitRoutePictures_TouristRoutes_TouristRouteId",
                table: "TourisitRoutePictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TourisitRoutePictures",
                table: "TourisitRoutePictures");

            migrationBuilder.RenameTable(
                name: "TourisitRoutePictures",
                newName: "TouristRoutePictures");

            migrationBuilder.RenameIndex(
                name: "IX_TourisitRoutePictures_TouristRouteId",
                table: "TouristRoutePictures",
                newName: "IX_TouristRoutePictures_TouristRouteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TouristRoutePictures",
                table: "TouristRoutePictures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TouristRoutePictures_TouristRoutes_TouristRouteId",
                table: "TouristRoutePictures",
                column: "TouristRouteId",
                principalTable: "TouristRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TouristRoutePictures_TouristRoutes_TouristRouteId",
                table: "TouristRoutePictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TouristRoutePictures",
                table: "TouristRoutePictures");

            migrationBuilder.RenameTable(
                name: "TouristRoutePictures",
                newName: "TourisitRoutePictures");

            migrationBuilder.RenameIndex(
                name: "IX_TouristRoutePictures_TouristRouteId",
                table: "TourisitRoutePictures",
                newName: "IX_TourisitRoutePictures_TouristRouteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TourisitRoutePictures",
                table: "TourisitRoutePictures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TourisitRoutePictures_TouristRoutes_TouristRouteId",
                table: "TourisitRoutePictures",
                column: "TouristRouteId",
                principalTable: "TouristRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
