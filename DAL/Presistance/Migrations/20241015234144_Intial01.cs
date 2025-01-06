using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class Intial01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>("DepartmentCodeSequence", startValue: 1000, incrementBy: 1);
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", nullable: false, defaultValueSql: "CONCAT('Dep', NEXT VALUE FOR DepartmentCodeSequence)"),
                    CreationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, computedColumnSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropSequence(
       name: "DepartmentCodeSequence");
        }
    }
}
