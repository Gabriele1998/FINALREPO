using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetMvc.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoAnagrafica",
                columns: table => new
                {
                    TipoAnagraficaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descrizione = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAnagrafica", x => x.TipoAnagraficaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoContatto",
                columns: table => new
                {
                    TipoContattoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descrizione = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoContatto", x => x.TipoContattoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoIndirizzo",
                columns: table => new
                {
                    TipoIndirizzoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descrizione = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIndirizzo", x => x.TipoIndirizzoId);
                });

            migrationBuilder.CreateTable(
                name: "Anagrafica",
                columns: table => new
                {
                    AnagraficaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CodiceAnagrafica = table.Column<string>(nullable: true),
                    IsAzienda = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Cognome = table.Column<string>(nullable: true),
                    RagioneSociale = table.Column<string>(nullable: true),
                    PartitaIva = table.Column<string>(nullable: true),
                    CodiceFiscale = table.Column<string>(nullable: true),
                    TipoAnagraficaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anagrafica", x => x.AnagraficaId);
                    table.ForeignKey(
                        name: "FK_Anagrafica_TipoAnagrafica_TipoAnagraficaId",
                        column: x => x.TipoAnagraficaId,
                        principalTable: "TipoAnagrafica",
                        principalColumn: "TipoAnagraficaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contatti",
                columns: table => new
                {
                    ContattiId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Valore = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    AnagraficaId = table.Column<int>(nullable: false),
                    TipoContattoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatti", x => x.ContattiId);
                    table.ForeignKey(
                        name: "FK_Contatti_Anagrafica_AnagraficaId",
                        column: x => x.AnagraficaId,
                        principalTable: "Anagrafica",
                        principalColumn: "AnagraficaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contatti_TipoContatto_TipoContattoId",
                        column: x => x.TipoContattoId,
                        principalTable: "TipoContatto",
                        principalColumn: "TipoContattoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Indirizzi",
                columns: table => new
                {
                    IndirizziId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nazione = table.Column<string>(nullable: true),
                    Regione = table.Column<string>(nullable: true),
                    Provincia = table.Column<string>(nullable: true),
                    Citta = table.Column<string>(nullable: true),
                    Denominazione = table.Column<string>(nullable: true),
                    Cap = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    AnagraficaId = table.Column<int>(nullable: false),
                    TipoIndirizzoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indirizzi", x => x.IndirizziId);
                    table.ForeignKey(
                        name: "FK_Indirizzi_Anagrafica_AnagraficaId",
                        column: x => x.AnagraficaId,
                        principalTable: "Anagrafica",
                        principalColumn: "AnagraficaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Indirizzi_TipoIndirizzo_TipoIndirizzoId",
                        column: x => x.TipoIndirizzoId,
                        principalTable: "TipoIndirizzo",
                        principalColumn: "TipoIndirizzoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anagrafica_TipoAnagraficaId",
                table: "Anagrafica",
                column: "TipoAnagraficaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contatti_AnagraficaId",
                table: "Contatti",
                column: "AnagraficaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contatti_TipoContattoId",
                table: "Contatti",
                column: "TipoContattoId");

            migrationBuilder.CreateIndex(
                name: "IX_Indirizzi_AnagraficaId",
                table: "Indirizzi",
                column: "AnagraficaId");

            migrationBuilder.CreateIndex(
                name: "IX_Indirizzi_TipoIndirizzoId",
                table: "Indirizzi",
                column: "TipoIndirizzoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contatti");

            migrationBuilder.DropTable(
                name: "Indirizzi");

            migrationBuilder.DropTable(
                name: "TipoContatto");

            migrationBuilder.DropTable(
                name: "Anagrafica");

            migrationBuilder.DropTable(
                name: "TipoIndirizzo");

            migrationBuilder.DropTable(
                name: "TipoAnagrafica");
        }
    }
}
