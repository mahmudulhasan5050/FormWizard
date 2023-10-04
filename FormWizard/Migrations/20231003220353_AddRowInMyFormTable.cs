using Microsoft.EntityFrameworkCore.Migrations;

namespace FormWizard.Migrations
{
    public partial class AddRowInMyFormTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInUse",
                table: "MyForms",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInUse",
                table: "MyForms");
        }
    }
}
