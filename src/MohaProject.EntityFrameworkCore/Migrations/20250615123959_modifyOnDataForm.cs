using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MohaProject.Migrations
{
    /// <inheritdoc />
    public partial class modifyOnDataForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "DataForms");

            migrationBuilder.RenameColumn(
                name: "TiktokUrl",
                table: "DataForms",
                newName: "XUrl");

            migrationBuilder.RenameColumn(
                name: "ProjectLinks",
                table: "DataForms",
                newName: "Vision");

            migrationBuilder.RenameColumn(
                name: "ProjectDetails",
                table: "DataForms",
                newName: "UniversityName");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "DataForms",
                newName: "ThirdProjectName");

            migrationBuilder.RenameColumn(
                name: "GithubUrl",
                table: "DataForms",
                newName: "ThirdProjectDescription");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "DataForms",
                newName: "ThirdPositionTitle");

            migrationBuilder.RenameColumn(
                name: "Experience",
                table: "DataForms",
                newName: "ThirdPositionEndDate");

            migrationBuilder.RenameColumn(
                name: "CertificationName",
                table: "DataForms",
                newName: "ThirdPositionDescription");

            migrationBuilder.AddColumn<string>(
                name: "DateOfGraduation",
                table: "DataForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "DataForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacebookUrl",
                table: "DataForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstPositionDescription",
                table: "DataForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstPositionEndDate",
                table: "DataForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstPositionTitle",
                table: "DataForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstProjectDescription",
                table: "DataForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstProjectName",
                table: "DataForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondPositionDescription",
                table: "DataForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondPositionEndDate",
                table: "DataForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondPositionTitle",
                table: "DataForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondProjectDescription",
                table: "DataForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondProjectName",
                table: "DataForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Skills",
                table: "DataForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfGraduation",
                table: "DataForms");

            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "DataForms");

            migrationBuilder.DropColumn(
                name: "FacebookUrl",
                table: "DataForms");

            migrationBuilder.DropColumn(
                name: "FirstPositionDescription",
                table: "DataForms");

            migrationBuilder.DropColumn(
                name: "FirstPositionEndDate",
                table: "DataForms");

            migrationBuilder.DropColumn(
                name: "FirstPositionTitle",
                table: "DataForms");

            migrationBuilder.DropColumn(
                name: "FirstProjectDescription",
                table: "DataForms");

            migrationBuilder.DropColumn(
                name: "FirstProjectName",
                table: "DataForms");

            migrationBuilder.DropColumn(
                name: "SecondPositionDescription",
                table: "DataForms");

            migrationBuilder.DropColumn(
                name: "SecondPositionEndDate",
                table: "DataForms");

            migrationBuilder.DropColumn(
                name: "SecondPositionTitle",
                table: "DataForms");

            migrationBuilder.DropColumn(
                name: "SecondProjectDescription",
                table: "DataForms");

            migrationBuilder.DropColumn(
                name: "SecondProjectName",
                table: "DataForms");

            migrationBuilder.DropColumn(
                name: "Skills",
                table: "DataForms");

            migrationBuilder.RenameColumn(
                name: "XUrl",
                table: "DataForms",
                newName: "TiktokUrl");

            migrationBuilder.RenameColumn(
                name: "Vision",
                table: "DataForms",
                newName: "ProjectLinks");

            migrationBuilder.RenameColumn(
                name: "UniversityName",
                table: "DataForms",
                newName: "ProjectDetails");

            migrationBuilder.RenameColumn(
                name: "ThirdProjectName",
                table: "DataForms",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "ThirdProjectDescription",
                table: "DataForms",
                newName: "GithubUrl");

            migrationBuilder.RenameColumn(
                name: "ThirdPositionTitle",
                table: "DataForms",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "ThirdPositionEndDate",
                table: "DataForms",
                newName: "Experience");

            migrationBuilder.RenameColumn(
                name: "ThirdPositionDescription",
                table: "DataForms",
                newName: "CertificationName");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "DataForms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
