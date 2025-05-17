using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuroraTrace.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    matricula = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    cargo = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    telefone = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localizacoes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    latitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    longitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    registrada_em = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    endereco = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    cidade = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    tamanho_metros = table.Column<double>(type: "BINARY_DOUBLE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cameras",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    posicao = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    PatioId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    instalada_em = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cameras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cameras_Patios_PatioId",
                        column: x => x.PatioId,
                        principalTable: "Patios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Motos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    placa = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    modelo = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ultima_atualizacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    PatioId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    FuncionarioId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    LocalizacaoId = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motos_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Motos_Localizacoes_LocalizacaoId",
                        column: x => x.LocalizacaoId,
                        principalTable: "Localizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Motos_Patios_PatioId",
                        column: x => x.PatioId,
                        principalTable: "Patios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Imagens",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    caminho_arquivo = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    capturada_em = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CameraId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MotoId = table.Column<long>(type: "NUMBER(19)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imagens_Cameras_CameraId",
                        column: x => x.CameraId,
                        principalTable: "Cameras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Imagens_Motos_MotoId",
                        column: x => x.MotoId,
                        principalTable: "Motos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cameras_PatioId",
                table: "Cameras",
                column: "PatioId");

            migrationBuilder.CreateIndex(
                name: "IX_Imagens_CameraId",
                table: "Imagens",
                column: "CameraId");

            migrationBuilder.CreateIndex(
                name: "IX_Imagens_MotoId",
                table: "Imagens",
                column: "MotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Motos_FuncionarioId",
                table: "Motos",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Motos_LocalizacaoId",
                table: "Motos",
                column: "LocalizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Motos_PatioId",
                table: "Motos",
                column: "PatioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imagens");

            migrationBuilder.DropTable(
                name: "Cameras");

            migrationBuilder.DropTable(
                name: "Motos");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Localizacoes");

            migrationBuilder.DropTable(
                name: "Patios");
        }
    }
}
