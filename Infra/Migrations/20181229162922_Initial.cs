using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adquirente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adquirente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bandeira",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bandeira", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aliquota",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdAdquirente = table.Column<Guid>(nullable: false),
                    IdBandeira = table.Column<Guid>(nullable: false),
                    Percentual = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aliquota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aliquota_Adquirente_IdAdquirente",
                        column: x => x.IdAdquirente,
                        principalTable: "Adquirente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aliquota_Bandeira_IdBandeira",
                        column: x => x.IdBandeira,
                        principalTable: "Bandeira",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemTransacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdTransacao = table.Column<Guid>(nullable: false),
                    IdAliquota = table.Column<Guid>(nullable: false),
                    NumeroCartao = table.Column<string>(nullable: true),
                    Validade = table.Column<DateTime>(nullable: false),
                    Cvv = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTransacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemTransacao_Aliquota_IdAliquota",
                        column: x => x.IdAliquota,
                        principalTable: "Aliquota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemTransacao_Transacao_IdTransacao",
                        column: x => x.IdTransacao,
                        principalTable: "Transacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Adquirente",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("6a3cf263-33a6-4f99-9601-162406e764e8"), "Elo" },
                    { new Guid("af1b1c35-6c19-427c-99c0-e8d694358685"), "Visa" },
                    { new Guid("adfa74d2-0c42-4173-acff-fedfc0aa2a47"), "Master" }
                });

            migrationBuilder.InsertData(
                table: "Bandeira",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("45304af0-3056-4e30-aaca-c4fd5db7fbdb"), "Cielo" },
                    { new Guid("970c4e0b-65c5-4c59-9a50-07a34f3c6886"), "Elavon" },
                    { new Guid("f5ae6f11-11d6-4da8-8554-5e63816ca018"), "GetNet" }
                });

            migrationBuilder.InsertData(
                table: "Aliquota",
                columns: new[] { "Id", "IdAdquirente", "IdBandeira", "Percentual" },
                values: new object[,]
                {
                    { new Guid("898601c0-8fc6-4eb0-bf9f-b1d362f37315"), new Guid("af1b1c35-6c19-427c-99c0-e8d694358685"), new Guid("45304af0-3056-4e30-aaca-c4fd5db7fbdb"), 0.03m },
                    { new Guid("10fe7f05-016b-49a4-bcd2-0dca30c349cf"), new Guid("adfa74d2-0c42-4173-acff-fedfc0aa2a47"), new Guid("45304af0-3056-4e30-aaca-c4fd5db7fbdb"), 0.02m },
                    { new Guid("7c090179-de71-4f05-a138-ef9621e5ee6a"), new Guid("6a3cf263-33a6-4f99-9601-162406e764e8"), new Guid("45304af0-3056-4e30-aaca-c4fd5db7fbdb"), 0.01m },
                    { new Guid("9764532c-b9d0-4731-a821-87ac6f348d3a"), new Guid("af1b1c35-6c19-427c-99c0-e8d694358685"), new Guid("970c4e0b-65c5-4c59-9a50-07a34f3c6886"), 1.5m },
                    { new Guid("f5143c6d-6ee9-44d5-82e6-676bcade27a5"), new Guid("adfa74d2-0c42-4173-acff-fedfc0aa2a47"), new Guid("970c4e0b-65c5-4c59-9a50-07a34f3c6886"), 1.08m },
                    { new Guid("0d4ed50a-7882-425d-8dd3-9e8fcccc13d2"), new Guid("6a3cf263-33a6-4f99-9601-162406e764e8"), new Guid("970c4e0b-65c5-4c59-9a50-07a34f3c6886"), 0.95m },
                    { new Guid("b219fdea-97d6-43c5-8def-2874abb84bc6"), new Guid("af1b1c35-6c19-427c-99c0-e8d694358685"), new Guid("f5ae6f11-11d6-4da8-8554-5e63816ca018"), 1.07m },
                    { new Guid("f3d074b0-1949-4279-b437-71ff0645edbf"), new Guid("adfa74d2-0c42-4173-acff-fedfc0aa2a47"), new Guid("f5ae6f11-11d6-4da8-8554-5e63816ca018"), 1.14m },
                    { new Guid("a0921c93-08a7-4c29-b193-d92ca032c00d"), new Guid("6a3cf263-33a6-4f99-9601-162406e764e8"), new Guid("f5ae6f11-11d6-4da8-8554-5e63816ca018"), 1.02m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aliquota_IdAdquirente",
                table: "Aliquota",
                column: "IdAdquirente");

            migrationBuilder.CreateIndex(
                name: "IX_Aliquota_IdBandeira",
                table: "Aliquota",
                column: "IdBandeira");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTransacao_IdAliquota",
                table: "ItemTransacao",
                column: "IdAliquota");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTransacao_IdTransacao",
                table: "ItemTransacao",
                column: "IdTransacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemTransacao");

            migrationBuilder.DropTable(
                name: "Aliquota");

            migrationBuilder.DropTable(
                name: "Transacao");

            migrationBuilder.DropTable(
                name: "Adquirente");

            migrationBuilder.DropTable(
                name: "Bandeira");
        }
    }
}
