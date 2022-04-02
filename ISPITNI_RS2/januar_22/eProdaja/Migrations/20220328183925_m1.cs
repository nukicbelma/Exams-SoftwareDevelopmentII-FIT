using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eProdaja.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PregledNarudzbi",
                columns: table => new
                {
                    PregledNarudzbiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojNarudzbe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumOd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumDo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MinIznos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IznosNarudzbe = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProizvodiId = table.Column<int>(type: "int", nullable: false),
                    KupciId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PregledNarudzbi", x => x.PregledNarudzbiId);
                    table.ForeignKey(
                        name: "FK_PregledNarudzbi_Kupci_KupciId",
                        column: x => x.KupciId,
                        principalTable: "Kupci",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PregledNarudzbi_Proizvodi_ProizvodiId",
                        column: x => x.ProizvodiId,
                        principalTable: "Proizvodi",
                        principalColumn: "ProizvodID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Narudzbe",
                columns: new[] { "NarudzbaID", "BrojNarudzbe", "Datum", "KupacID", "Otkazano", "Status" },
                values: new object[,]
                {
                    { 1, "bn1", new DateTime(2022, 3, 28, 20, 39, 18, 864, DateTimeKind.Local).AddTicks(9276), 1, false, true },
                    { 2, "bn2", new DateTime(2022, 3, 28, 20, 39, 18, 884, DateTimeKind.Local).AddTicks(9128), 2, false, true },
                    { 3, "bn3", new DateTime(2022, 3, 28, 20, 39, 18, 885, DateTimeKind.Local).AddTicks(47), 3, false, true },
                    { 4, "bn4", new DateTime(2022, 3, 28, 20, 39, 18, 885, DateTimeKind.Local).AddTicks(247), 1, false, true }
                });

            migrationBuilder.InsertData(
                table: "PregledNarudzbi",
                columns: new[] { "PregledNarudzbiId", "BrojNarudzbe", "DatumDo", "DatumOd", "IznosNarudzbe", "KupciId", "MinIznos", "ProizvodiId" },
                values: new object[,]
                {
                    { 1, "bn1", new DateTime(2022, 3, 28, 20, 39, 18, 887, DateTimeKind.Local).AddTicks(5058), new DateTime(2022, 3, 18, 20, 39, 18, 887, DateTimeKind.Local).AddTicks(3907), 1000m, 1, 44m, 1 },
                    { 2, "bn2", new DateTime(2022, 3, 28, 20, 39, 18, 888, DateTimeKind.Local).AddTicks(393), new DateTime(2022, 3, 18, 20, 39, 18, 888, DateTimeKind.Local).AddTicks(308), 1000m, 2, 100m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Izlazi",
                columns: new[] { "IzlazID", "BrojRacuna", "Datum", "IznosBezPDV", "IznosSaPDV", "KorisnikID", "NarudzbaID", "SkladisteID", "Zakljucen" },
                values: new object[,]
                {
                    { 1, "bn1", new DateTime(2022, 3, 28, 20, 39, 18, 886, DateTimeKind.Local).AddTicks(3328), 900m, 1000m, 1, 1, 1, false },
                    { 2, "bn2", new DateTime(2022, 3, 28, 20, 39, 18, 886, DateTimeKind.Local).AddTicks(9773), 900m, 1000m, 1, 2, 2, false },
                    { 3, "bn3", new DateTime(2022, 3, 28, 20, 39, 18, 887, DateTimeKind.Local).AddTicks(126), 900m, 1000m, 1, 3, 1, false },
                    { 4, "bn4", new DateTime(2022, 3, 28, 20, 39, 18, 887, DateTimeKind.Local).AddTicks(238), 900m, 1000m, 1, 4, 2, false }
                });

            migrationBuilder.InsertData(
                table: "NarudzbaStavke",
                columns: new[] { "NarudzbaStavkaID", "Kolicina", "NarudzbaID", "ProizvodID" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 2, 2 },
                    { 5, 1, 2, 1 },
                    { 3, 3, 3, 3 },
                    { 4, 4, 4, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PregledNarudzbi_KupciId",
                table: "PregledNarudzbi",
                column: "KupciId");

            migrationBuilder.CreateIndex(
                name: "IX_PregledNarudzbi_ProizvodiId",
                table: "PregledNarudzbi",
                column: "ProizvodiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PregledNarudzbi");

            migrationBuilder.DeleteData(
                table: "Izlazi",
                keyColumn: "IzlazID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Izlazi",
                keyColumn: "IzlazID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Izlazi",
                keyColumn: "IzlazID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Izlazi",
                keyColumn: "IzlazID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "NarudzbaStavke",
                keyColumn: "NarudzbaStavkaID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NarudzbaStavke",
                keyColumn: "NarudzbaStavkaID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NarudzbaStavke",
                keyColumn: "NarudzbaStavkaID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "NarudzbaStavke",
                keyColumn: "NarudzbaStavkaID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "NarudzbaStavke",
                keyColumn: "NarudzbaStavkaID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Narudzbe",
                keyColumn: "NarudzbaID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Narudzbe",
                keyColumn: "NarudzbaID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Narudzbe",
                keyColumn: "NarudzbaID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Narudzbe",
                keyColumn: "NarudzbaID",
                keyValue: 4);
        }
    }
}
