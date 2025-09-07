using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuroraFuncionarios",
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
                    table.PrimaryKey("PK_AuroraFuncionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuroraLocalizacoes",
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
                    table.PrimaryKey("PK_AuroraLocalizacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuroraPatios",
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
                    table.PrimaryKey("PK_AuroraPatios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuroraCameras",
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
                    table.PrimaryKey("PK_AuroraCameras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuroraCameras_AuroraPatios_PatioId",
                        column: x => x.PatioId,
                        principalTable: "AuroraPatios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuroraMotos",
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
                    table.PrimaryKey("PK_AuroraMotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuroraMotos_AuroraFuncionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "AuroraFuncionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AuroraMotos_AuroraLocalizacoes_LocalizacaoId",
                        column: x => x.LocalizacaoId,
                        principalTable: "AuroraLocalizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuroraMotos_AuroraPatios_PatioId",
                        column: x => x.PatioId,
                        principalTable: "AuroraPatios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuroraImagens",
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
                    table.PrimaryKey("PK_AuroraImagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuroraImagens_AuroraCameras_CameraId",
                        column: x => x.CameraId,
                        principalTable: "AuroraCameras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuroraImagens_AuroraMotos_MotoId",
                        column: x => x.MotoId,
                        principalTable: "AuroraMotos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuroraCameras_PatioId",
                table: "AuroraCameras",
                column: "PatioId");

            migrationBuilder.CreateIndex(
                name: "IX_AuroraImagens_CameraId",
                table: "AuroraImagens",
                column: "CameraId");

            migrationBuilder.CreateIndex(
                name: "IX_AuroraImagens_MotoId",
                table: "AuroraImagens",
                column: "MotoId");

            migrationBuilder.CreateIndex(
                name: "IX_AuroraMotos_FuncionarioId",
                table: "AuroraMotos",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_AuroraMotos_LocalizacaoId",
                table: "AuroraMotos",
                column: "LocalizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_AuroraMotos_PatioId",
                table: "AuroraMotos",
                column: "PatioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuroraImagens");

            migrationBuilder.DropTable(
                name: "AuroraCameras");

            migrationBuilder.DropTable(
                name: "AuroraMotos");

            migrationBuilder.DropTable(
                name: "AuroraFuncionarios");

            migrationBuilder.DropTable(
                name: "AuroraLocalizacoes");

            migrationBuilder.DropTable(
                name: "AuroraPatios");
        }
    }
}
