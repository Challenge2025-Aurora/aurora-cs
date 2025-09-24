using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuroraMotos_AuroraFuncionarios_FuncionarioId",
                table: "AuroraMotos");

            migrationBuilder.DropForeignKey(
                name: "FK_AuroraMotos_AuroraLocalizacoes_LocalizacaoId",
                table: "AuroraMotos");

            migrationBuilder.DropForeignKey(
                name: "FK_AuroraMotos_AuroraPatios_PatioId",
                table: "AuroraMotos");

            migrationBuilder.DropTable(
                name: "AuroraFuncionarios");

            migrationBuilder.DropTable(
                name: "AuroraImagens");

            migrationBuilder.DropTable(
                name: "AuroraLocalizacoes");

            migrationBuilder.DropTable(
                name: "AuroraCameras");

            migrationBuilder.DropIndex(
                name: "IX_AuroraMotos_FuncionarioId",
                table: "AuroraMotos");

            migrationBuilder.DropIndex(
                name: "IX_AuroraMotos_LocalizacaoId",
                table: "AuroraMotos");

            migrationBuilder.DropIndex(
                name: "IX_AuroraMotos_PatioId",
                table: "AuroraMotos");

            migrationBuilder.DropColumn(
                name: "cidade",
                table: "AuroraPatios");

            migrationBuilder.DropColumn(
                name: "endereco",
                table: "AuroraPatios");

            migrationBuilder.DropColumn(
                name: "tamanho_metros",
                table: "AuroraPatios");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "AuroraMotos");

            migrationBuilder.DropColumn(
                name: "LocalizacaoId",
                table: "AuroraMotos");

            migrationBuilder.DropColumn(
                name: "PatioId",
                table: "AuroraMotos");

            migrationBuilder.RenameColumn(
                name: "ultima_atualizacao",
                table: "AuroraMotos",
                newName: "atualizado_em");

            migrationBuilder.AddColumn<int>(
                name: "cols",
                table: "AuroraPatios",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "rows",
                table: "AuroraPatios",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "AuroraMotos",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AddColumn<string>(
                name: "ultimo_setor",
                table: "AuroraMotos",
                type: "NVARCHAR2(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ultimo_slot",
                table: "AuroraMotos",
                type: "NVARCHAR2(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AuroraDeteccoes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    placa = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: true),
                    modelo_prob = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    confianca = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    bbox_x = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    bbox_y = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    bbox_w = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    bbox_h = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    setor_estimado = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: true),
                    slot_estimado = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: true),
                    timestamp = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuroraDeteccoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuroraEventos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    tipo = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    descricao = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    criado_em = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    moto_id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuroraEventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuroraEventos_AuroraMotos_moto_id",
                        column: x => x.moto_id,
                        principalTable: "AuroraMotos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuroraSetores",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    slots = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    patio_id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuroraSetores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuroraSetores_AuroraPatios_patio_id",
                        column: x => x.patio_id,
                        principalTable: "AuroraPatios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuroraEventos_moto_id",
                table: "AuroraEventos",
                column: "moto_id");

            migrationBuilder.CreateIndex(
                name: "IX_AuroraSetores_patio_id",
                table: "AuroraSetores",
                column: "patio_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuroraDeteccoes");

            migrationBuilder.DropTable(
                name: "AuroraEventos");

            migrationBuilder.DropTable(
                name: "AuroraSetores");

            migrationBuilder.DropColumn(
                name: "cols",
                table: "AuroraPatios");

            migrationBuilder.DropColumn(
                name: "rows",
                table: "AuroraPatios");

            migrationBuilder.DropColumn(
                name: "ultimo_setor",
                table: "AuroraMotos");

            migrationBuilder.DropColumn(
                name: "ultimo_slot",
                table: "AuroraMotos");

            migrationBuilder.RenameColumn(
                name: "atualizado_em",
                table: "AuroraMotos",
                newName: "ultima_atualizacao");

            migrationBuilder.AddColumn<string>(
                name: "cidade",
                table: "AuroraPatios",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "endereco",
                table: "AuroraPatios",
                type: "NVARCHAR2(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "tamanho_metros",
                table: "AuroraPatios",
                type: "BINARY_DOUBLE",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "AuroraMotos",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AddColumn<long>(
                name: "FuncionarioId",
                table: "AuroraMotos",
                type: "NUMBER(19)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LocalizacaoId",
                table: "AuroraMotos",
                type: "NUMBER(19)",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PatioId",
                table: "AuroraMotos",
                type: "NUMBER(19)",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "AuroraCameras",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PatioId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    instalada_em = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    posicao = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
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
                name: "AuroraFuncionarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    cargo = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    matricula = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
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
                name: "AuroraImagens",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CameraId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MotoId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    caminho_arquivo = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    capturada_em = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_AuroraMotos_AuroraFuncionarios_FuncionarioId",
                table: "AuroraMotos",
                column: "FuncionarioId",
                principalTable: "AuroraFuncionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_AuroraMotos_AuroraLocalizacoes_LocalizacaoId",
                table: "AuroraMotos",
                column: "LocalizacaoId",
                principalTable: "AuroraLocalizacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AuroraMotos_AuroraPatios_PatioId",
                table: "AuroraMotos",
                column: "PatioId",
                principalTable: "AuroraPatios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
