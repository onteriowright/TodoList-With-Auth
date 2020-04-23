using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_AspNetUsers_ApplicationUserId",
                table: "TodoItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_ToDoStatus_ToDoStatusId",
                table: "TodoItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoItems",
                table: "TodoItems");

            migrationBuilder.RenameTable(
                name: "TodoItems",
                newName: "ToDoItem");

            migrationBuilder.RenameIndex(
                name: "IX_TodoItems_ToDoStatusId",
                table: "ToDoItem",
                newName: "IX_ToDoItem_ToDoStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_TodoItems_ApplicationUserId",
                table: "ToDoItem",
                newName: "IX_ToDoItem_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDoItem",
                table: "ToDoItem",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ToDoStatusViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    ToDoStatusId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoStatusViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoStatusViewModel_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToDoStatusViewModel_ToDoStatus_ToDoStatusId",
                        column: x => x.ToDoStatusId,
                        principalTable: "ToDoStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fab00b44-55f0-43f9-b45f-db650e11fc7e", "AQAAAAEAACcQAAAAEI3RFeXo1IbpAQ7RMe+myry81oQ6S1k/nXuaX9Tul92A/8D29QdjR7xadUrHe2Y6YQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoStatusViewModel_ApplicationUserId",
                table: "ToDoStatusViewModel",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoStatusViewModel_ToDoStatusId",
                table: "ToDoStatusViewModel",
                column: "ToDoStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItem_AspNetUsers_ApplicationUserId",
                table: "ToDoItem",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItem_ToDoStatus_ToDoStatusId",
                table: "ToDoItem",
                column: "ToDoStatusId",
                principalTable: "ToDoStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItem_AspNetUsers_ApplicationUserId",
                table: "ToDoItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItem_ToDoStatus_ToDoStatusId",
                table: "ToDoItem");

            migrationBuilder.DropTable(
                name: "ToDoStatusViewModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDoItem",
                table: "ToDoItem");

            migrationBuilder.RenameTable(
                name: "ToDoItem",
                newName: "TodoItems");

            migrationBuilder.RenameIndex(
                name: "IX_ToDoItem_ToDoStatusId",
                table: "TodoItems",
                newName: "IX_TodoItems_ToDoStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ToDoItem_ApplicationUserId",
                table: "TodoItems",
                newName: "IX_TodoItems_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoItems",
                table: "TodoItems",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e19738b9-1234-437f-bc2c-919c91297f19", "AQAAAAEAACcQAAAAENnxmJoEJ7lQ1BBsr4nftuQrfr0WZmct/hSnyRihfF1z7xrA5GEfhD9XL6mVDDOpew==" });

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_AspNetUsers_ApplicationUserId",
                table: "TodoItems",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_ToDoStatus_ToDoStatusId",
                table: "TodoItems",
                column: "ToDoStatusId",
                principalTable: "ToDoStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
