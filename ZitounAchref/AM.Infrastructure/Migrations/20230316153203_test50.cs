using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class test50 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_MyFlight_flightFK",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Passengers_passengerFK",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "tickets");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_flightFK",
                table: "tickets",
                newName: "IX_tickets_flightFK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tickets",
                table: "tickets",
                columns: new[] { "passengerFK", "flightFK" });

            migrationBuilder.CreateTable(
                name: "sections",
                columns: table => new
                {
                    idSection = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sections", x => x.idSection);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    seatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    seatNumber = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    size = table.Column<int>(type: "int", nullable: false),
                    planeFK = table.Column<int>(type: "int", nullable: false),
                    sectionFK = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.seatId);
                    table.ForeignKey(
                        name: "FK_Seat_Planes_planeFK",
                        column: x => x.planeFK,
                        principalTable: "Planes",
                        principalColumn: "planeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seat_sections_sectionFK",
                        column: x => x.sectionFK,
                        principalTable: "sections",
                        principalColumn: "idSection",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    DateReservation = table.Column<DateTime>(type: "date", nullable: false),
                    passengerFK = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    seatFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => new { x.passengerFK, x.seatFK, x.DateReservation });
                    table.ForeignKey(
                        name: "FK_Reservations_Passengers_passengerFK",
                        column: x => x.passengerFK,
                        principalTable: "Passengers",
                        principalColumn: "passportNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Seat_seatFK",
                        column: x => x.seatFK,
                        principalTable: "Seat",
                        principalColumn: "seatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_seatFK",
                table: "Reservations",
                column: "seatFK");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_planeFK",
                table: "Seat",
                column: "planeFK");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_sectionFK",
                table: "Seat",
                column: "sectionFK");

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_MyFlight_flightFK",
                table: "tickets",
                column: "flightFK",
                principalTable: "MyFlight",
                principalColumn: "flightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_Passengers_passengerFK",
                table: "tickets",
                column: "passengerFK",
                principalTable: "Passengers",
                principalColumn: "passportNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tickets_MyFlight_flightFK",
                table: "tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_Passengers_passengerFK",
                table: "tickets");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "sections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tickets",
                table: "tickets");

            migrationBuilder.RenameTable(
                name: "tickets",
                newName: "Ticket");

            migrationBuilder.RenameIndex(
                name: "IX_tickets_flightFK",
                table: "Ticket",
                newName: "IX_Ticket_flightFK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                columns: new[] { "passengerFK", "flightFK" });

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_MyFlight_flightFK",
                table: "Ticket",
                column: "flightFK",
                principalTable: "MyFlight",
                principalColumn: "flightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Passengers_passengerFK",
                table: "Ticket",
                column: "passengerFK",
                principalTable: "Passengers",
                principalColumn: "passportNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
