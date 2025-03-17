using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presentation.Migrations
{
    /// <inheritdoc />
    public partial class UpdateConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskStatus_TaskStatusEntityId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_TaskStatus_Name",
                table: "TaskStatus");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskStatus_TaskStatusEntityId",
                table: "Tasks",
                column: "TaskStatusEntityId",
                principalTable: "TaskStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskStatus_TaskStatusEntityId",
                table: "Tasks");

            migrationBuilder.CreateIndex(
                name: "IX_TaskStatus_Name",
                table: "TaskStatus",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskStatus_TaskStatusEntityId",
                table: "Tasks",
                column: "TaskStatusEntityId",
                principalTable: "TaskStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
