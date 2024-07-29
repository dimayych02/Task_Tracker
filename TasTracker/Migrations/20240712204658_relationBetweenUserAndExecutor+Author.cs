using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTracker.Migrations
{
    /// <inheritdoc />
    public partial class relationBetweenUserAndExecutorAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Users_TaskAuthorUserId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Executors_Users_ExecutorTaskUserId",
                table: "Executors");

            migrationBuilder.DropColumn(
                name: "LastTimeRoleChanged",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "LastTaskTimeModification",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "SprintEndTime",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "SprintStartTime",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "ExecutorTaskUserId",
                table: "Executors",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Executors_ExecutorTaskUserId",
                table: "Executors",
                newName: "IX_Executors_UserId");

            migrationBuilder.RenameColumn(
                name: "TaskAuthorUserId",
                table: "Authors",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Authors_TaskAuthorUserId",
                table: "Authors",
                newName: "IX_Authors_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Users_UserId",
                table: "Authors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Executors_Users_UserId",
                table: "Executors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Users_UserId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Executors_Users_UserId",
                table: "Executors");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Executors",
                newName: "ExecutorTaskUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Executors_UserId",
                table: "Executors",
                newName: "IX_Executors_ExecutorTaskUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Authors",
                newName: "TaskAuthorUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Authors_UserId",
                table: "Authors",
                newName: "IX_Authors_TaskAuthorUserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastTimeRoleChanged",
                table: "UserRoles",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastTaskTimeModification",
                table: "Tasks",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateOnly>(
                name: "SprintEndTime",
                table: "Tasks",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "SprintStartTime",
                table: "Tasks",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Users_TaskAuthorUserId",
                table: "Authors",
                column: "TaskAuthorUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Executors_Users_ExecutorTaskUserId",
                table: "Executors",
                column: "ExecutorTaskUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
