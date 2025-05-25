using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MohaProject.Migrations
{
    /// <inheritdoc />
    public partial class fixProjectId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TemplateSystemName",
                table: "DataForms");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "DataForms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "DataForms");

            migrationBuilder.AddColumn<string>(
                name: "TemplateSystemName",
                table: "DataForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
