using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class modules_to_studentdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Modules",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modules_StudentId",
                table: "Modules",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Students_StudentId",
                table: "Modules",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Students_StudentId",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Modules_StudentId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Modules");
        }
    }
}
