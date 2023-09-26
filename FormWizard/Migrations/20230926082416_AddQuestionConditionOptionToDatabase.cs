using Microsoft.EntityFrameworkCore.Migrations;

namespace FormWizard.Migrations
{
    public partial class AddQuestionConditionOptionToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionConditionsOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConditionOptionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderOfDisplay = table.Column<int>(type: "int", nullable: true),
                    QuestionConditionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionConditionsOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionConditionsOptions_QuestionConditions_QuestionConditionId",
                        column: x => x.QuestionConditionId,
                        principalTable: "QuestionConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionConditionsOptions_QuestionConditionId",
                table: "QuestionConditionsOptions",
                column: "QuestionConditionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionConditionsOptions");
        }
    }
}
