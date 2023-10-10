using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fiap.Api.Donation.Migrations
{
    /// <inheritdoc />
    public partial class Usuario_Produto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUsuario = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EmailUsuario = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Regra = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Disponivel = table.Column<bool>(type: "bit", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExpiracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SugestaoTroca = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    TipoProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_Produto_TipoProduto_TipoProdutoId",
                        column: x => x.TipoProdutoId,
                        principalTable: "TipoProduto",
                        principalColumn: "TipoProdutoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produto_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "UsuarioId", "EmailUsuario", "NomeUsuario", "Regra", "Senha" },
                values: new object[,]
                {
                    { 1, "sa@fiap.com.br", "Super Admin", "admin", "123456" },
                    { 2, "william.iso@hotmail.com", "William Iso", "admin", "123456" },
                    { 3, "rafael.iso@fiap.com.br", "Rafael Iso", "admin", "123456" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_TipoProdutoId",
                table: "Produto",
                column: "TipoProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_UsuarioId",
                table: "Produto",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
