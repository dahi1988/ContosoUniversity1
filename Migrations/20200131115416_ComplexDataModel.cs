using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ContosoUniversity.Migrations
{
    public partial class ComplexDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                    name: "Title",
                    table: "Course",
                    maxLength: 50,
                    nullable: true,
                    oldClrType: typeof(string),
                    oldNullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "DepartmentID",
            //    table: "Course",
            //    nullable: false,
            //    defaultValue: 0); 
            migrationBuilder.CreateTable(
    name: "Department",
    columns: table => new
    {
        DepartmentID = table.Column<int>(type: "int", nullable: false)
            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        Budget = table.Column<decimal>(type: "money", nullable: false),
        InstructorID = table.Column<int>(type: "int", nullable: true),
        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_Department", x => x.DepartmentID);
        table.ForeignKey(
            name: "FK_Department_Instructor_InstructorID",
            column: x => x.InstructorID,
            principalTable: "Instructor",
            principalColumn: "ID",
            onDelete: ReferentialAction.Restrict);
    });

            migrationBuilder.Sql("INSERT INTO dbo.Department (Name, Budget, StartDate) VALUES ('Temp', 0.00, GETDATE())");
            // Default value for FK points to department created above, with
            // defaultValue changed to 1 in following AddColumn statement.

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "Course",
                nullable: false,
                defaultValue: 1);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
