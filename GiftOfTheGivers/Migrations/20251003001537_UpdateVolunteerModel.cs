using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiftOfTheGivers.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVolunteerModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Donations");

            migrationBuilder.RenameColumn(
                name: "VolunteerID",
                table: "Volunteers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DonationID",
                table: "Donations",
                newName: "Id");

            migrationBuilder.AddColumn<bool>(
                name: "IsAssigned",
                table: "Volunteers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TaskAssigned",
                table: "Volunteers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaskPreference",
                table: "Volunteers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsResourceDonation",
                table: "Donations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PickupLocation",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Donations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ResourceType",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IncidentReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncidentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncidentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReporterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReporterContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentReports", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncidentReports");

            migrationBuilder.DropColumn(
                name: "IsAssigned",
                table: "Volunteers");

            migrationBuilder.DropColumn(
                name: "TaskAssigned",
                table: "Volunteers");

            migrationBuilder.DropColumn(
                name: "TaskPreference",
                table: "Volunteers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "IsResourceDonation",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "PickupLocation",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "ResourceType",
                table: "Donations");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Volunteers",
                newName: "VolunteerID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Donations",
                newName: "DonationID");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Donations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
