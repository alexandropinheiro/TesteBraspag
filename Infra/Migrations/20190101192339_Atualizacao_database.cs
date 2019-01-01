using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class Atualizacao_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTransacao_Aliquota_IdAliquota",
                table: "ItemTransacao");

            migrationBuilder.DeleteData(
                table: "Aliquota",
                keyColumn: "Id",
                keyValue: new Guid("0d4ed50a-7882-425d-8dd3-9e8fcccc13d2"));

            migrationBuilder.DeleteData(
                table: "Aliquota",
                keyColumn: "Id",
                keyValue: new Guid("10fe7f05-016b-49a4-bcd2-0dca30c349cf"));

            migrationBuilder.DeleteData(
                table: "Aliquota",
                keyColumn: "Id",
                keyValue: new Guid("7c090179-de71-4f05-a138-ef9621e5ee6a"));

            migrationBuilder.DeleteData(
                table: "Aliquota",
                keyColumn: "Id",
                keyValue: new Guid("898601c0-8fc6-4eb0-bf9f-b1d362f37315"));

            migrationBuilder.DeleteData(
                table: "Aliquota",
                keyColumn: "Id",
                keyValue: new Guid("9764532c-b9d0-4731-a821-87ac6f348d3a"));

            migrationBuilder.DeleteData(
                table: "Aliquota",
                keyColumn: "Id",
                keyValue: new Guid("a0921c93-08a7-4c29-b193-d92ca032c00d"));

            migrationBuilder.DeleteData(
                table: "Aliquota",
                keyColumn: "Id",
                keyValue: new Guid("b219fdea-97d6-43c5-8def-2874abb84bc6"));

            migrationBuilder.DeleteData(
                table: "Aliquota",
                keyColumn: "Id",
                keyValue: new Guid("f3d074b0-1949-4279-b437-71ff0645edbf"));

            migrationBuilder.DeleteData(
                table: "Aliquota",
                keyColumn: "Id",
                keyValue: new Guid("f5143c6d-6ee9-44d5-82e6-676bcade27a5"));

            migrationBuilder.DeleteData(
                table: "Adquirente",
                keyColumn: "Id",
                keyValue: new Guid("6a3cf263-33a6-4f99-9601-162406e764e8"));

            migrationBuilder.DeleteData(
                table: "Adquirente",
                keyColumn: "Id",
                keyValue: new Guid("adfa74d2-0c42-4173-acff-fedfc0aa2a47"));

            migrationBuilder.DeleteData(
                table: "Adquirente",
                keyColumn: "Id",
                keyValue: new Guid("af1b1c35-6c19-427c-99c0-e8d694358685"));

            migrationBuilder.DeleteData(
                table: "Bandeira",
                keyColumn: "Id",
                keyValue: new Guid("45304af0-3056-4e30-aaca-c4fd5db7fbdb"));

            migrationBuilder.DeleteData(
                table: "Bandeira",
                keyColumn: "Id",
                keyValue: new Guid("970c4e0b-65c5-4c59-9a50-07a34f3c6886"));

            migrationBuilder.DeleteData(
                table: "Bandeira",
                keyColumn: "Id",
                keyValue: new Guid("f5ae6f11-11d6-4da8-8554-5e63816ca018"));

            migrationBuilder.RenameColumn(
                name: "IdAliquota",
                table: "ItemTransacao",
                newName: "IdTaxa");

            migrationBuilder.RenameIndex(
                name: "IX_ItemTransacao_IdAliquota",
                table: "ItemTransacao",
                newName: "IX_ItemTransacao_IdTaxa");

            migrationBuilder.AlterColumn<string>(
                name: "Validade",
                table: "ItemTransacao",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.InsertData(
                table: "Adquirente",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("4be3ba77-fdef-491a-ade6-b29db233fdf2"), "Elo" },
                    { new Guid("80d9f4ab-85ea-4230-af0d-b7b1a41abb53"), "Visa" },
                    { new Guid("b2218bd2-6f38-42c5-9e75-c8b273f6c832"), "Master" }
                });

            migrationBuilder.InsertData(
                table: "Bandeira",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("8ed73dba-86e8-41bf-9ac2-f15d005d9d64"), "Cielo" },
                    { new Guid("567e7c1d-4283-44de-930b-0fc79a7bf682"), "Elavon" },
                    { new Guid("70795956-6672-4ab6-9fa2-d63a90b6a785"), "GetNet" }
                });

            migrationBuilder.InsertData(
                table: "Aliquota",
                columns: new[] { "Id", "IdAdquirente", "IdBandeira", "Percentual" },
                values: new object[,]
                {
                    { new Guid("ca70d04c-99d4-4950-9704-fa025dbbd8ed"), new Guid("80d9f4ab-85ea-4230-af0d-b7b1a41abb53"), new Guid("8ed73dba-86e8-41bf-9ac2-f15d005d9d64"), 0.0003m },
                    { new Guid("016d44b8-f25f-4f96-8223-17e6860a2a8f"), new Guid("b2218bd2-6f38-42c5-9e75-c8b273f6c832"), new Guid("8ed73dba-86e8-41bf-9ac2-f15d005d9d64"), 0.0002m },
                    { new Guid("952ff89a-3cfd-4ded-869e-eb56057074b2"), new Guid("4be3ba77-fdef-491a-ade6-b29db233fdf2"), new Guid("8ed73dba-86e8-41bf-9ac2-f15d005d9d64"), 0.0001m },
                    { new Guid("8e4949c0-531f-4462-bb13-b54095abfc4e"), new Guid("80d9f4ab-85ea-4230-af0d-b7b1a41abb53"), new Guid("567e7c1d-4283-44de-930b-0fc79a7bf682"), 0.015m },
                    { new Guid("e8b1a661-0a65-4bce-bc68-2a873824bbc7"), new Guid("b2218bd2-6f38-42c5-9e75-c8b273f6c832"), new Guid("567e7c1d-4283-44de-930b-0fc79a7bf682"), 0.0108m },
                    { new Guid("1182cb5d-faf9-4328-a7ba-c04e85fe2b65"), new Guid("4be3ba77-fdef-491a-ade6-b29db233fdf2"), new Guid("567e7c1d-4283-44de-930b-0fc79a7bf682"), 0.0095m },
                    { new Guid("e42d76e7-7372-4c0d-bea7-ee2595ae5c99"), new Guid("80d9f4ab-85ea-4230-af0d-b7b1a41abb53"), new Guid("70795956-6672-4ab6-9fa2-d63a90b6a785"), 0.0107m },
                    { new Guid("02f30a31-3851-4b86-a33f-4f65d18a35b1"), new Guid("b2218bd2-6f38-42c5-9e75-c8b273f6c832"), new Guid("70795956-6672-4ab6-9fa2-d63a90b6a785"), 0.0114m },
                    { new Guid("d69b0e35-1cbc-4661-9a88-f7b28085c318"), new Guid("4be3ba77-fdef-491a-ade6-b29db233fdf2"), new Guid("70795956-6672-4ab6-9fa2-d63a90b6a785"), 0.0102m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTransacao_Aliquota_IdTaxa",
                table: "ItemTransacao",
                column: "IdTaxa",
                principalTable: "Aliquota",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTransacao_Aliquota_IdTaxa",
                table: "ItemTransacao");

            migrationBuilder.DeleteData(
                table: "Aliquota",
                keyColumn: "Id",
                keyValue: new Guid("016d44b8-f25f-4f96-8223-17e6860a2a8f"));

            migrationBuilder.DeleteData(
                table: "Aliquota",
                keyColumn: "Id",
                keyValue: new Guid("02f30a31-3851-4b86-a33f-4f65d18a35b1"));

            migrationBuilder.DeleteData(
                table: "Aliquota",
                keyColumn: "Id",
                keyValue: new Guid("1182cb5d-faf9-4328-a7ba-c04e85fe2b65"));

            migrationBuilder.DeleteData(
                table: "Aliquota",
                keyColumn: "Id",
                keyValue: new Guid("8e4949c0-531f-4462-bb13-b54095abfc4e"));

            migrationBuilder.DeleteData(
                table: "Aliquota",
                keyColumn: "Id",
                keyValue: new Guid("952ff89a-3cfd-4ded-869e-eb56057074b2"));

            migrationBuilder.DeleteData(
                table: "Aliquota",
                keyColumn: "Id",
                keyValue: new Guid("ca70d04c-99d4-4950-9704-fa025dbbd8ed"));

            migrationBuilder.DeleteData(
                table: "Aliquota",
                keyColumn: "Id",
                keyValue: new Guid("d69b0e35-1cbc-4661-9a88-f7b28085c318"));

            migrationBuilder.DeleteData(
                table: "Aliquota",
                keyColumn: "Id",
                keyValue: new Guid("e42d76e7-7372-4c0d-bea7-ee2595ae5c99"));

            migrationBuilder.DeleteData(
                table: "Aliquota",
                keyColumn: "Id",
                keyValue: new Guid("e8b1a661-0a65-4bce-bc68-2a873824bbc7"));

            migrationBuilder.DeleteData(
                table: "Adquirente",
                keyColumn: "Id",
                keyValue: new Guid("4be3ba77-fdef-491a-ade6-b29db233fdf2"));

            migrationBuilder.DeleteData(
                table: "Adquirente",
                keyColumn: "Id",
                keyValue: new Guid("80d9f4ab-85ea-4230-af0d-b7b1a41abb53"));

            migrationBuilder.DeleteData(
                table: "Adquirente",
                keyColumn: "Id",
                keyValue: new Guid("b2218bd2-6f38-42c5-9e75-c8b273f6c832"));

            migrationBuilder.DeleteData(
                table: "Bandeira",
                keyColumn: "Id",
                keyValue: new Guid("567e7c1d-4283-44de-930b-0fc79a7bf682"));

            migrationBuilder.DeleteData(
                table: "Bandeira",
                keyColumn: "Id",
                keyValue: new Guid("70795956-6672-4ab6-9fa2-d63a90b6a785"));

            migrationBuilder.DeleteData(
                table: "Bandeira",
                keyColumn: "Id",
                keyValue: new Guid("8ed73dba-86e8-41bf-9ac2-f15d005d9d64"));

            migrationBuilder.RenameColumn(
                name: "IdTaxa",
                table: "ItemTransacao",
                newName: "IdAliquota");

            migrationBuilder.RenameIndex(
                name: "IX_ItemTransacao_IdTaxa",
                table: "ItemTransacao",
                newName: "IX_ItemTransacao_IdAliquota");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Validade",
                table: "ItemTransacao",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTransacao_Aliquota_IdAliquota",
                table: "ItemTransacao",
                column: "IdAliquota",
                principalTable: "Aliquota",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
