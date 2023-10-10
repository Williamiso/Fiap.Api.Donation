using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fiap.Api.Donation.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoProduto",
                columns: table => new
                {
                    TipoProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProduto", x => x.TipoProdutoId);
                });

            migrationBuilder.InsertData(
                table: "TipoProduto",
                columns: new[] { "TipoProdutoId", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, "Descrição para celular", "Celular" },
                    { 2, "Descrição para TV", "TVs" },
                    { 3, "Descrição para ar-condicionado", "Ar-Condicionado" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoProduto");
        }
    }
}
