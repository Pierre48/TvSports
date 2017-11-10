using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TvSports.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
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
                name: "Match_hilo",
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
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
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
                    ParentId = table.Column<int>(type: "int4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zone_Zone_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Zone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    ParticipantAwayId = table.Column<int>(type: "int4", nullable: false),
                    ParticipantHomeId = table.Column<int>(type: "int4", nullable: false),
                    PointsAxay = table.Column<int>(type: "int4", nullable: true),
                    PointsHome = table.Column<int>(type: "int4", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Participant_ParticipantAwayId",
                        column: x => x.ParticipantAwayId,
                        principalTable: "Participant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Match_Participant_ParticipantHomeId",
                        column: x => x.ParticipantHomeId,
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
                    SportFK = table.Column<int>(type: "int4", nullable: false),
                    ZoneFK = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competition_Sport_SportFK",
                        column: x => x.SportFK,
                        principalTable: "Sport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Competition_Zone_ZoneFK",
                        column: x => x.ZoneFK,
                        principalTable: "Zone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Channel_Name",
                table: "Channel",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Competition_SportFK",
                table: "Competition",
                column: "SportFK");

            migrationBuilder.CreateIndex(
                name: "IX_Competition_ZoneFK",
                table: "Competition",
                column: "ZoneFK");

            migrationBuilder.CreateIndex(
                name: "IX_Match_ParticipantAwayId",
                table: "Match",
                column: "ParticipantAwayId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_ParticipantHomeId",
                table: "Match",
                column: "ParticipantHomeId");

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
                name: "IX_Zone_ParentId",
                table: "Zone",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Channel");

            migrationBuilder.DropTable(
                name: "Competition");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Sport");

            migrationBuilder.DropTable(
                name: "Zone");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropSequence(
                name: "Channel_hilo");

            migrationBuilder.DropSequence(
                name: "Competition_hilo");

            migrationBuilder.DropSequence(
                name: "Match_hilo");

            migrationBuilder.DropSequence(
                name: "Participant_hilo");

            migrationBuilder.DropSequence(
                name: "Sport_hilo");

            migrationBuilder.DropSequence(
                name: "Zone_hilo");
        }
    }
}
