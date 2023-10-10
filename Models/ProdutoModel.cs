using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Api.Donation.Models
{
    [Table("Produto")]
    public class ProdutoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdutoId { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }

        public bool Disponivel { get; set; }

        public double Valor { get; set; }

        [StringLength(150)]
        public string Descricao { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public DateTime DataExpiracao { get; set; }

        [StringLength(200)]
        public string SugestaoTroca { get; set; }

        //Foreign Key
        public int UsuarioId { get; set; }

        //Navigation Property
        [ForeignKey(nameof(UsuarioId))]

        public UsuarioModel Usuario { get; set; }

        //Foreign Key
        public int TipoProdutoId { get; set; }

        //Navigation Property
        //[ForeignKey("TipoProdutoId")]
        [ForeignKey(nameof(TipoProdutoId))]
        public TipoProdutoModel TipoProduto { get; set; }

        public ProdutoModel()
        {

        }

        public ProdutoModel(int produtoId, string nome, bool disponivel, double valor, string descricao, DateTime dataCadastro, DateTime dataExpiracao, string sugestaoTroca, int usuarioId, UsuarioModel usuario, int tipoProdutoId, TipoProdutoModel tipoProduto)
        {
            ProdutoId = produtoId;
            Nome = nome;
            Disponivel = disponivel;
            Valor = valor;
            Descricao = descricao;
            DataCadastro = dataCadastro;
            DataExpiracao = dataExpiracao;
            SugestaoTroca = sugestaoTroca;
            UsuarioId = usuarioId;
            Usuario = usuario;
            TipoProdutoId = tipoProdutoId;
            TipoProduto = tipoProduto;
        }
    }
}
