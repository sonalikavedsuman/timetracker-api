using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTrackerApp.Migrations
{
    /// <inheritdoc />
    public partial class Updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_attendance_assignments_assignments",
                table: "attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_attendance_timesheets_timesheets",
                table: "attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_timesheets_projects_project_id",
                table: "timesheets");

            migrationBuilder.DropForeignKey(
                name: "FK_timesheets_users_user_id",
                table: "timesheets");

            migrationBuilder.DropIndex(
                name: "IX_timesheets_project_id",
                table: "timesheets");

            migrationBuilder.DropIndex(
                name: "IX_timesheets_user_id",
                table: "timesheets");

            migrationBuilder.DropIndex(
                name: "IX_attendance_assignments",
                table: "attendance");

            migrationBuilder.DropIndex(
                name: "IX_attendance_timesheets",
                table: "attendance");

            migrationBuilder.DropColumn(
                name: "assignments",
                table: "attendance");

            migrationBuilder.DropColumn(
                name: "timesheets",
                table: "attendance");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "assignments",
                table: "attendance",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "timesheets",
                table: "attendance",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_timesheets_project_id",
                table: "timesheets",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_timesheets_user_id",
                table: "timesheets",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_attendance_assignments",
                table: "attendance",
                column: "assignments");

            migrationBuilder.CreateIndex(
                name: "IX_attendance_timesheets",
                table: "attendance",
                column: "timesheets");

            migrationBuilder.AddForeignKey(
                name: "FK_attendance_assignments_assignments",
                table: "attendance",
                column: "assignments",
                principalTable: "assignments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_attendance_timesheets_timesheets",
                table: "attendance",
                column: "timesheets",
                principalTable: "timesheets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_timesheets_projects_project_id",
                table: "timesheets",
                column: "project_id",
                principalTable: "projects",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_timesheets_users_user_id",
                table: "timesheets",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
