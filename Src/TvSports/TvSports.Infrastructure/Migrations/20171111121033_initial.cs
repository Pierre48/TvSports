using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TvSports.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "Channel_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Competition_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Game_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Participant_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Sport_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Zone_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Channel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Nickname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Tricode = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ZoneForeignKey = table.Column<int>(type: "int4", nullable: false),
                    ZoneParentForeignKey = table.Column<int>(type: "int4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zone_Zone_ZoneParentForeignKey",
                        column: x => x.ZoneParentForeignKey,
                        principalTable: "Zone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalTeamInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Key = table.Column<string>(type: "text", nullable: true),
                    TeamId = table.Column<int>(type: "int4", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalTeamInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditionalTeamInformation_Participant_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Participant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    ParticipantAwayForeignKey = table.Column<int>(type: "int4", nullable: false),
                    ParticipantHomeForeignKey = table.Column<int>(type: "int4", nullable: false),
                    PointsAway = table.Column<int>(type: "int4", nullable: true),
                    PointsHome = table.Column<int>(type: "int4", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_Participant_ParticipantAwayForeignKey",
                        column: x => x.ParticipantAwayForeignKey,
                        principalTable: "Participant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Game_Participant_ParticipantHomeForeignKey",
                        column: x => x.ParticipantHomeForeignKey,
                        principalTable: "Participant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Competition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    SportForeignKey = table.Column<int>(type: "int4", nullable: false),
                    ZoneForeignKey = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competition_Sport_SportForeignKey",
                        column: x => x.SportForeignKey,
                        principalTable: "Sport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Competition_Zone_ZoneForeignKey",
                        column: x => x.ZoneForeignKey,
                        principalTable: "Zone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionInstance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CompetitionForeignKey = table.Column<int>(type: "int4", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionInstance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetitionInstance_Competition_CompetitionForeignKey",
                        column: x => x.CompetitionForeignKey,
                        principalTable: "Competition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionInstanceParticipant",
                columns: table => new
                {
                    CompetitionInstanceId = table.Column<int>(type: "int4", nullable: false),
                    ParticipantId = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionInstanceParticipant", x => new { x.CompetitionInstanceId, x.ParticipantId });
                    table.ForeignKey(
                        name: "FK_CompetitionInstanceParticipant_CompetitionInstance_CompetitionInstanceId",
                        column: x => x.CompetitionInstanceId,
                        principalTable: "CompetitionInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionInstanceParticipant_Participant_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalTeamInformation_TeamId",
                table: "AdditionalTeamInformation",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Channel_Name",
                table: "Channel",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Competition_SportForeignKey",
                table: "Competition",
                column: "SportForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Competition_ZoneForeignKey",
                table: "Competition",
                column: "ZoneForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionInstance_CompetitionForeignKey",
                table: "CompetitionInstance",
                column: "CompetitionForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionInstanceParticipant_ParticipantId",
                table: "CompetitionInstanceParticipant",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_ParticipantAwayForeignKey",
                table: "Game",
                column: "ParticipantAwayForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Game_ParticipantHomeForeignKey",
                table: "Game",
                column: "ParticipantHomeForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_Name",
                table: "Participant",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sport_Name",
                table: "Sport",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zone_Name",
                table: "Zone",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zone_ZoneParentForeignKey",
                table: "Zone",
                column: "ZoneParentForeignKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalTeamInformation");

            migrationBuilder.DropTable(
                name: "Channel");

            migrationBuilder.DropTable(
                name: "CompetitionInstanceParticipant");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "CompetitionInstance");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "Competition");

            migrationBuilder.DropTable(
                name: "Sport");

            migrationBuilder.DropTable(
                name: "Zone");

            migrationBuilder.DropSequence(
                name: "Channel_hilo");

            migrationBuilder.DropSequence(
                name: "Competition_hilo");

            migrationBuilder.DropSequence(
                name: "Game_hilo");

            migrationBuilder.DropSequence(
                name: "Participant_hilo");

            migrationBuilder.DropSequence(
                name: "Sport_hilo");

            migrationBuilder.DropSequence(
                name: "Zone_hilo");
        }
    }
}
