using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArcheologicalSite.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Archeologists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "TEXT", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProfessionalRegisterId = table.Column<int>(type: "INTEGER", nullable: false),
                    Profession = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archeologists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paleontologists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProfessionalRegisterId = table.Column<int>(type: "INTEGER", nullable: false),
                    Profession = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paleontologists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artefacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Function = table.Column<string>(type: "TEXT", nullable: true),
                    Dimension = table.Column<string>(type: "TEXT", nullable: false),
                    Material = table.Column<string>(type: "TEXT", nullable: false),
                    ArcheologistId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Period = table.Column<string>(type: "TEXT", nullable: false),
                    Origin = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artefacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artefacts_Archeologists_ArcheologistId",
                        column: x => x.ArcheologistId,
                        principalTable: "Archeologists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fossils",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ScientificName = table.Column<string>(type: "TEXT", nullable: false),
                    Species = table.Column<string>(type: "TEXT", nullable: true),
                    Condition = table.Column<string>(type: "TEXT", nullable: true),
                    PaleontologistId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Period = table.Column<string>(type: "TEXT", nullable: false),
                    Origin = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fossils", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fossils_Paleontologists_PaleontologistId",
                        column: x => x.PaleontologistId,
                        principalTable: "Paleontologists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artefacts_ArcheologistId",
                table: "Artefacts",
                column: "ArcheologistId");

            migrationBuilder.CreateIndex(
                name: "IX_Fossils_PaleontologistId",
                table: "Fossils",
                column: "PaleontologistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artefacts");

            migrationBuilder.DropTable(
                name: "Fossils");

            migrationBuilder.DropTable(
                name: "Archeologists");

            migrationBuilder.DropTable(
                name: "Paleontologists");
        }
    }
}
