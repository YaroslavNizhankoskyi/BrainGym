using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrainGym.Infrastructure.Migrations
{
    public partial class RecommendationEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Recommendation",
                table: "FactorRecommendations");

            migrationBuilder.DropColumn(
                name: "Recommendation",
                table: "ExpectedResults");

            migrationBuilder.RenameColumn(
                name: "SleepFactor",
                table: "Scores",
                newName: "SleepRate");

            migrationBuilder.RenameColumn(
                name: "MentalFactor",
                table: "Scores",
                newName: "MentalRate");

            migrationBuilder.RenameColumn(
                name: "HealthFactor",
                table: "Scores",
                newName: "HealthRate");

            migrationBuilder.AddColumn<double>(
                name: "Coefficient",
                table: "FactorRecommendations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "RecommendationId",
                table: "FactorRecommendations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RecommendationId",
                table: "ExpectedResults",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Recommendation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Text = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recommendation", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FactorRecommendations_RecommendationId",
                table: "FactorRecommendations",
                column: "RecommendationId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpectedResults_RecommendationId",
                table: "ExpectedResults",
                column: "RecommendationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpectedResults_Recommendation_RecommendationId",
                table: "ExpectedResults",
                column: "RecommendationId",
                principalTable: "Recommendation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FactorRecommendations_Recommendation_RecommendationId",
                table: "FactorRecommendations",
                column: "RecommendationId",
                principalTable: "Recommendation",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpectedResults_Recommendation_RecommendationId",
                table: "ExpectedResults");

            migrationBuilder.DropForeignKey(
                name: "FK_FactorRecommendations_Recommendation_RecommendationId",
                table: "FactorRecommendations");

            migrationBuilder.DropTable(
                name: "Recommendation");

            migrationBuilder.DropIndex(
                name: "IX_FactorRecommendations_RecommendationId",
                table: "FactorRecommendations");

            migrationBuilder.DropIndex(
                name: "IX_ExpectedResults_RecommendationId",
                table: "ExpectedResults");

            migrationBuilder.DropColumn(
                name: "Coefficient",
                table: "FactorRecommendations");

            migrationBuilder.DropColumn(
                name: "RecommendationId",
                table: "FactorRecommendations");

            migrationBuilder.DropColumn(
                name: "RecommendationId",
                table: "ExpectedResults");

            migrationBuilder.RenameColumn(
                name: "SleepRate",
                table: "Scores",
                newName: "SleepFactor");

            migrationBuilder.RenameColumn(
                name: "MentalRate",
                table: "Scores",
                newName: "MentalFactor");

            migrationBuilder.RenameColumn(
                name: "HealthRate",
                table: "Scores",
                newName: "HealthFactor");

            migrationBuilder.AddColumn<string>(
                name: "Recommendation",
                table: "FactorRecommendations",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Recommendation",
                table: "ExpectedResults",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");
        }
    }
}
