using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTracker.Migrations
{
    /// <inheritdoc />
    public partial class RemoverUserIdTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Authors_AuthorId",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Tasks",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Authors_AuthorId",
                table: "Tasks",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Authors_AuthorId",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Tasks",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Authors_AuthorId",
                table: "Tasks",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
