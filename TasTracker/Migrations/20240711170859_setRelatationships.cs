using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TaskTracker.Migrations
{
    /// <inheritdoc />
    public partial class setRelatationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Authors_AuthorId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Executors_ExecutorId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AuthorId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ExecutorId",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "ExecutorId",
                table: "Executors",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Authors",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AuthorId",
                table: "Tasks",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ExecutorId",
                table: "Tasks",
                column: "ExecutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Tasks_AuthorId",
                table: "Authors",
                column: "AuthorId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Executors_Tasks_ExecutorId",
                table: "Executors",
                column: "ExecutorId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Authors_AuthorId",
                table: "Tasks",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Executors_ExecutorId",
                table: "Tasks",
                column: "ExecutorId",
                principalTable: "Executors",
                principalColumn: "ExecutorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Tasks_AuthorId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Executors_Tasks_ExecutorId",
                table: "Executors");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Authors_AuthorId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Executors_ExecutorId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AuthorId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ExecutorId",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "ExecutorId",
                table: "Executors",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Authors",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Authors_AuthorId",
                table: "Tasks",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Executors_ExecutorId",
                table: "Tasks",
                column: "ExecutorId",
                principalTable: "Executors",
                principalColumn: "ExecutorId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
