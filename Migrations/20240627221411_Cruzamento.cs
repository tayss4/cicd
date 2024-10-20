using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Web.Trafego.Migrations
{
    /// <inheritdoc />
    public partial class Cruzamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CRUZAMENTO",
                columns: table => new
                {
                    CruzamentoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Rua1 = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Rua2 = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRUZAMENTO", x => x.CruzamentoId);
                });

            migrationBuilder.CreateTable(
                name: "HORARIOPICO",
                columns: table => new
                {
                    HorarioPicoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    HoraInicio = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    HoraTermino = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CruzamentoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HORARIOPICO", x => x.HorarioPicoId);
                    table.ForeignKey(
                        name: "FK_HORARIOPICO_CRUZAMENTO_CruzamentoId",
                        column: x => x.CruzamentoId,
                        principalTable: "CRUZAMENTO",
                        principalColumn: "CruzamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PREVISAO",
                columns: table => new
                {
                    PrevisaoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Hora = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    MelhorAlternativa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NumeroCarros = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CruzamentoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PREVISAO", x => x.PrevisaoId);
                    table.ForeignKey(
                        name: "FK_PREVISAO_CRUZAMENTO_CruzamentoId",
                        column: x => x.CruzamentoId,
                        principalTable: "CRUZAMENTO",
                        principalColumn: "CruzamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REGISTRO",
                columns: table => new
                {
                    RegistroId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    HoraAbertura = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    HoraFechamento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    NumeroCarros = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CruzamentoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REGISTRO", x => x.RegistroId);
                    table.ForeignKey(
                        name: "FK_REGISTRO_CRUZAMENTO_CruzamentoId",
                        column: x => x.CruzamentoId,
                        principalTable: "CRUZAMENTO",
                        principalColumn: "CruzamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IDX_RUAS",
                table: "CRUZAMENTO",
                columns: new[] { "Rua1", "Rua2" });

            migrationBuilder.CreateIndex(
                name: "IX_HORARIOPICO_CruzamentoId",
                table: "HORARIOPICO",
                column: "CruzamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_PREVISAO_CruzamentoId",
                table: "PREVISAO",
                column: "CruzamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_REGISTRO_CruzamentoId",
                table: "REGISTRO",
                column: "CruzamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HORARIOPICO");

            migrationBuilder.DropTable(
                name: "PREVISAO");

            migrationBuilder.DropTable(
                name: "REGISTRO");

            migrationBuilder.DropTable(
                name: "CRUZAMENTO");
        }
    }
}
