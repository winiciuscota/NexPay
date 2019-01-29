using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NexPay.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(maxLength: 128, nullable: true),
                    cnpj = table.Column<string>(maxLength: 14, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Transferencia",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    usuario_id = table.Column<int>(nullable: false),
                    pagador_nome = table.Column<string>(maxLength: 128, nullable: true),
                    pagador_banco = table.Column<string>(maxLength: 3, nullable: true),
                    pagador_agencia = table.Column<string>(maxLength: 4, nullable: true),
                    pagador_conta = table.Column<string>(maxLength: 6, nullable: true),
                    beneficiario_nome = table.Column<string>(maxLength: 128, nullable: true),
                    beneficiario_banco = table.Column<string>(maxLength: 3, nullable: true),
                    beneficiario_agencia = table.Column<string>(maxLength: 4, nullable: true),
                    beneficiario_conta = table.Column<string>(maxLength: 6, nullable: true),
                    status = table.Column<decimal>(type: "numeric[15,2]", maxLength: 12, nullable: false),
                    tipo = table.Column<string>(maxLength: 4, nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferencia", x => x.id);
                    table.ForeignKey(
                        name: "FK_Transferencia_Usuario_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_usuario_id",
                table: "Transferencia",
                column: "usuario_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transferencia");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
