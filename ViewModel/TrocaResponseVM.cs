using Fiap.Api.Donation.Models;

namespace Fiap.Api.Donation.ViewModel
{
    public class TrocaResponseVM
    {
        public Guid TrocaId { get; set; }

        public DateTime DataCriacao { get; set; }

        public TrocaStatus Status { get; set; }

        public ProdutoResponseVM Produto1 { get; set; }

        public ProdutoResponseVM Produto2 { get; set; }

        public int UsuarioId { get; set; }


    }
}