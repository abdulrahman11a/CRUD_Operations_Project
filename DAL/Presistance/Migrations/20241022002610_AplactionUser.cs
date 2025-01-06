using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class AplactionUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isAgree",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAgree",
                table: "AspNetUsers");
        }
    }
}
