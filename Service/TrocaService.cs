using Fiap.Api.Donation.Repository;
using Fiap.Api.Donation.Repository.Interface;

namespace Fiap.Api.Donation.Service
{
    public class TrocaService
    {

        private readonly IProdutoRepository produtoRepository;

        private readonly ITrocaRepository trocaRepository;

        public TrocaService(IProdutoRepository _produtoRepository, ITrocaRepository _trocaRepository)
        {
            produtoRepository = _produtoRepository;
            trocaRepository = _trocaRepository;
        }

        public async Task<Guid> TrocarProdutos(Models.TrocaModel trocaModel)
        {
            var produto1 = await produtoRepository.FindById(trocaModel.ProdutoId1);
            var produto2 = await produtoRepository.FindById(trocaModel.ProdutoId2);

            if (produto1.Disponivel == false)
            {
                throw new Exception("Produto selecionado indisponível");
            }

            if (produto2.Disponivel == false)
            {
                throw new Exception("O seu produto já foi trocado");
            }

            if(produto1.UsuarioId == trocaModel.UsuarioId)
            {
                throw new Exception("Esse produto não pode ser escolhido pelo usuário da troca");
            }

            if(produto2.UsuarioId != trocaModel.UsuarioId)
            {
                throw new Exception("Não é possível trocar um produto de outro usuário");
            }

            if ((produto2.Valor / produto1.Valor) < 0.9)
            {
                throw new Exception("O seu produto tem o valor menor que 90% do produto selecionado");
            }

            produto1.Disponivel = false;
            produtoRepository.Update(produto1);

            produto2.Disponivel = false;
            produtoRepository.Update(produto2);

            trocaModel.Status = Models.TrocaStatus.Iniciado;
            trocaRepository.Insert(trocaModel);

            return trocaModel.TrocaId;
        }
    }
}