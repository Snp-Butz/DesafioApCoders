using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvc_web_app.Migrations
{
    public partial class database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inquilino",
                columns: table => new
                {
                    nome = table.Column<string>(type: "TEXT", nullable: false),
                    idade = table.Column<int>(type: "INTEGER", nullable: false),
                    sexo = table.Column<int>(type: "INTEGER", nullable: false),
                    telefone = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquilino", x => x.nome);
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
                    table.ForeignKey(
                        name: "FK_Unidade_Inquilino_proprietario",
                        column: x => x.proprietario,
                        principalTable: "Inquilino",
                        principalColumn: "nome",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Unidade_proprietario",
                table: "Unidade",
                column: "proprietario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Unidade");

            migrationBuilder.DropTable(
                name: "Inquilino");
        }
    }
}
