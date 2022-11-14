using Microsoft.EntityFrameworkCore.Migrations;

namespace Crm.UpSchool.DataAccessLayer.Migrations
{
    public partial class _mih_createtask2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "EmployeeTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTasks_AppUserId",
                table: "EmployeeTasks",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTasks_AspNetUsers_AppUserId",
                table: "EmployeeTasks",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTasks_AspNetUsers_AppUserId",
                table: "EmployeeTasks");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTasks_AppUserId",
                table: "EmployeeTasks");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "EmployeeTasks");
        }
    }
}
