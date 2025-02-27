using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class comp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1de1871b-97bc-4ea9-8d72-f9c2483cd566");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7c4e831-a3bf-4370-9b2d-535905477b87");

            migrationBuilder.AddColumn<string>(
                name: "AppuserId",
                table: "Comment",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6cd7913c-af93-4f2c-81be-f22e476c1f0c", null, "User", "USER" },
                    { "82f1d35e-af15-4c5d-bf10-66ce4286ffdc", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AppuserId",
                table: "Comment",
                column: "AppuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_AppuserId",
                table: "Comment",
                column: "AppuserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_AppuserId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_AppuserId",
                table: "Comment");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cd7913c-af93-4f2c-81be-f22e476c1f0c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82f1d35e-af15-4c5d-bf10-66ce4286ffdc");

            migrationBuilder.DropColumn(
                name: "AppuserId",
                table: "Comment");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1de1871b-97bc-4ea9-8d72-f9c2483cd566", null, "User", "USER" },
                    { "d7c4e831-a3bf-4370-9b2d-535905477b87", null, "Admin", "ADMIN" }
                });
        }
    }
}
