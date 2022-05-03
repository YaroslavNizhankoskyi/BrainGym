using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrainGym.Infrastructure.Migrations
{
    public partial class RecommendationsAndFactorsDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpectedResults_Recommendation_RecommendationId",
                table: "ExpectedResults");

            migrationBuilder.DropForeignKey(
                name: "FK_FactorRecommendations_Exercises_ExerciseId",
                table: "FactorRecommendations");

            migrationBuilder.DropForeignKey(
                name: "FK_FactorRecommendations_Recommendation_RecommendationId",
                table: "FactorRecommendations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recommendation",
                table: "Recommendation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FactorRecommendations",
                table: "FactorRecommendations");

            migrationBuilder.RenameTable(
                name: "Recommendation",
                newName: "Recommendations");

            migrationBuilder.RenameTable(
                name: "FactorRecommendations",
                newName: "Factors");

            migrationBuilder.RenameIndex(
                name: "IX_FactorRecommendations_RecommendationId",
                table: "Factors",
                newName: "IX_Factors_RecommendationId");

            migrationBuilder.RenameIndex(
                name: "IX_FactorRecommendations_ExerciseId",
                table: "Factors",
                newName: "IX_Factors_ExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recommendations",
                table: "Recommendations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Factors",
                table: "Factors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpectedResults_Recommendations_RecommendationId",
                table: "ExpectedResults",
                column: "RecommendationId",
                principalTable: "Recommendations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Factors_Exercises_ExerciseId",
                table: "Factors",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Factors_Recommendations_RecommendationId",
                table: "Factors",
                column: "RecommendationId",
                principalTable: "Recommendations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpectedResults_Recommendations_RecommendationId",
                table: "ExpectedResults");

            migrationBuilder.DropForeignKey(
                name: "FK_Factors_Exercises_ExerciseId",
                table: "Factors");

            migrationBuilder.DropForeignKey(
                name: "FK_Factors_Recommendations_RecommendationId",
                table: "Factors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recommendations",
                table: "Recommendations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Factors",
                table: "Factors");

            migrationBuilder.RenameTable(
                name: "Recommendations",
                newName: "Recommendation");

            migrationBuilder.RenameTable(
                name: "Factors",
                newName: "FactorRecommendations");

            migrationBuilder.RenameIndex(
                name: "IX_Factors_RecommendationId",
                table: "FactorRecommendations",
                newName: "IX_FactorRecommendations_RecommendationId");

            migrationBuilder.RenameIndex(
                name: "IX_Factors_ExerciseId",
                table: "FactorRecommendations",
                newName: "IX_FactorRecommendations_ExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recommendation",
                table: "Recommendation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FactorRecommendations",
                table: "FactorRecommendations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpectedResults_Recommendation_RecommendationId",
                table: "ExpectedResults",
                column: "RecommendationId",
                principalTable: "Recommendation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FactorRecommendations_Exercises_ExerciseId",
                table: "FactorRecommendations",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FactorRecommendations_Recommendation_RecommendationId",
                table: "FactorRecommendations",
                column: "RecommendationId",
                principalTable: "Recommendation",
                principalColumn: "Id");
        }
    }
}
