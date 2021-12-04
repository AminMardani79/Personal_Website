using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class modifyRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProject_ProjectCategorys_CategoryId",
                table: "CategoryProject");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProject_Projects_ProjectId",
                table: "CategoryProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryProject",
                table: "CategoryProject");

            migrationBuilder.RenameTable(
                name: "CategoryProject",
                newName: "CategoryProjects");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryProject_ProjectId",
                table: "CategoryProjects",
                newName: "IX_CategoryProjects_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryProjects",
                table: "CategoryProjects",
                columns: new[] { "CategoryId", "ProjectId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProjects_ProjectCategorys_CategoryId",
                table: "CategoryProjects",
                column: "CategoryId",
                principalTable: "ProjectCategorys",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProjects_Projects_ProjectId",
                table: "CategoryProjects",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProjects_ProjectCategorys_CategoryId",
                table: "CategoryProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProjects_Projects_ProjectId",
                table: "CategoryProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryProjects",
                table: "CategoryProjects");

            migrationBuilder.RenameTable(
                name: "CategoryProjects",
                newName: "CategoryProject");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryProjects_ProjectId",
                table: "CategoryProject",
                newName: "IX_CategoryProject_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryProject",
                table: "CategoryProject",
                columns: new[] { "CategoryId", "ProjectId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProject_ProjectCategorys_CategoryId",
                table: "CategoryProject",
                column: "CategoryId",
                principalTable: "ProjectCategorys",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProject_Projects_ProjectId",
                table: "CategoryProject",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
