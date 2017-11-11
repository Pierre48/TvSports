using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TvSports.Infrastructure.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompetitionInstanceId",
                table: "Game",
                type: "int4",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Game_CompetitionInstanceId",
                table: "Game",
                column: "CompetitionInstanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_CompetitionInstance_CompetitionInstanceId",
                table: "Game",
                column: "CompetitionInstanceId",
                principalTable: "CompetitionInstance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_CompetitionInstance_CompetitionInstanceId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_CompetitionInstanceId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "CompetitionInstanceId",
                table: "Game");
        }
    }
}
