using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvc_web_app.Migrations
{
    public partial class ModelToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DespesasDasUnidades",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    descricao = table.Column<string>(type: "TEXT", nullable: false),
                    tipoDespesa = table.Column<string>(type: "TEXT", nullable: false),
                    valor = table.Column<float>(type: "REAL", nullable: false),
                    vencimento_fatura = table.Column<DateTime>(type: "TEXT", nullable: false),
                    statusPagamento = table.Column<string>(type: "TEXT", nullable: false),
                    unidadeId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DespesasDasUnidades", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Inquilino",
                columns: table => new
                {
                    cpfCnpj = table.Column<string>(type: "TEXT", nullable: false),
                    nome = table.Column<string>(type: "TEXT", nullable: false),
                    idade = table.Column<int>(type: "INTEGER", nullable: false),
                    telefone = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    sexo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquilino", x => x.cpfCnpj);
                });

            migrationBuilder.CreateTable(
                name: "Unidade",
                columns: table => new
                {
                    indentificacao = table.Column<string>(type: "TEXT", nullable: false),
                    proprietario = table.Column<string>(type: "TEXT", nullable: false),
                    condominio = table.Column<string>(type: "TEXT", nullable: false),
                    endereco = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidade", x => x.indentificacao);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DespesasDasUnidades");

            migrationBuilder.DropTable(
                name: "Inquilino");

            migrationBuilder.DropTable(
                name: "Unidade");
        }
    }
}
