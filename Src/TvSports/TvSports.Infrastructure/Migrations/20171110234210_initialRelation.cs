using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TvSports.Infrastructure.Migrations
{
    public partial class initialRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Participant_ParticipantAwayId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Participant_ParticipantHomeId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_ParticipantAwayId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_ParticipantHomeId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "ParticipantAwayId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "ParticipantHomeId",
                table: "Game");

            migrationBuilder.CreateIndex(
                name: "IX_Game_ParticipantAwayForeignKey",
                table: "Game",
                column: "ParticipantAwayForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Game_ParticipantHomeForeignKey",
                table: "Game",
                column: "ParticipantHomeForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Participant_ParticipantAwayForeignKey",
                table: "Game",
                column: "ParticipantAwayForeignKey",
                principalTable: "Participant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Participant_ParticipantHomeForeignKey",
                table: "Game",
                column: "ParticipantHomeForeignKey",
                principalTable: "Participant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Participant_ParticipantAwayForeignKey",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Participant_ParticipantHomeForeignKey",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_ParticipantAwayForeignKey",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_ParticipantHomeForeignKey",
                table: "Game");

            migrationBuilder.AddColumn<int>(
                name: "ParticipantAwayId",
                table: "Game",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParticipantHomeId",
                table: "Game",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Game_ParticipantAwayId",
                table: "Game",
                column: "ParticipantAwayId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_ParticipantHomeId",
                table: "Game",
                column: "ParticipantHomeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Participant_ParticipantAwayId",
                table: "Game",
                column: "ParticipantAwayId",
                principalTable: "Participant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Participant_ParticipantHomeId",
                table: "Game",
                column: "ParticipantHomeId",
                principalTable: "Participant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
