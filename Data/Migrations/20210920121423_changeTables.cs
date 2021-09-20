using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class changeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MessageNumber",
                table: "ContactMessages",
                newName: "UserNumber");

            migrationBuilder.RenameColumn(
                name: "MessageName",
                table: "ContactMessages",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "MessageEmail",
                table: "ContactMessages",
                newName: "UserEmail");

            migrationBuilder.AddColumn<bool>(
                name: "IsCategoryDelete",
                table: "ProjectCategorys",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCategoryDelete",
                table: "ProjectCategorys");

            migrationBuilder.RenameColumn(
                name: "UserNumber",
                table: "ContactMessages",
                newName: "MessageNumber");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "ContactMessages",
                newName: "MessageName");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "ContactMessages",
                newName: "MessageEmail");
        }
    }
}
