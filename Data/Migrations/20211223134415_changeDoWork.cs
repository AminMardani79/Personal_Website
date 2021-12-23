using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class changeDoWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DoWorkImage",
                table: "DoWorks",
                newName: "DoWorkIcon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DoWorkIcon",
                table: "DoWorks",
                newName: "DoWorkImage");
        }
    }
}
