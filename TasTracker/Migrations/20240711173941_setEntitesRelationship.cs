using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTracker.Migrations
{
    /// <inheritdoc />
    public partial class setEntitesRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Authors_TaskAuthorAuthorId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Executors_ExecutorId1",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AuthorId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ExecutorId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ExecutorId1",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TaskAuthorAuthorId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ExecutorId1",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskAuthorAuthorId",
                table: "Tasks");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AuthorId",
                table: "Tasks",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ExecutorId",
                table: "Tasks",
                column: "ExecutorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tasks_AuthorId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ExecutorId",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "ExecutorId1",
                table: "Tasks",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskAuthorAuthorId",
                table: "Tasks",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AuthorId",
                table: "Tasks",
                column: "AuthorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ExecutorId",
                table: "Tasks",
                column: "ExecutorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ExecutorId1",
                table: "Tasks",
                column: "ExecutorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskAuthorAuthorId",
                table: "Tasks",
                column: "TaskAuthorAuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Authors_TaskAuthorAuthorId",
                table: "Tasks",
                column: "TaskAuthorAuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Executors_ExecutorId1",
                table: "Tasks",
                column: "ExecutorId1",
                principalTable: "Executors",
                principalColumn: "ExecutorId");
        }
    }
}
