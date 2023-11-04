using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMBackend.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contracts",
                columns: table => new
                {
                    contractcode = table.Column<string>(type: "text", nullable: false),
                    contractname = table.Column<string>(type: "text", nullable: false),
                    client = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contracts", x => x.contractcode);
                });

            migrationBuilder.CreateTable(
                name: "contractstages",
                columns: table => new
                {
                    stagename = table.Column<string>(type: "text", nullable: false),
                    startdate = table.Column<DateOnly>(type: "date", nullable: false),
                    enddate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contractstages", x => x.stagename);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contracts");

            migrationBuilder.DropTable(
                name: "contractstages");
        }
    }
}
