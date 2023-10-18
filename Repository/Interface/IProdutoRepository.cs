using Fiap.Api.Donation.Models;

namespace Fiap.Api.Donation.Repository.Interface
{
    public interface IProdutoRepository
    {

        public Task<int> Count();

        public Task<IList<ProdutoModel>> GetAll(int pagina, int tamanho);

        public Task<IList<ProdutoModel>> GetAllOrderByDataCadastroAsc(DateTime? dataReferencia, int tamanho);

        public Task<IList<ProdutoModel>> FindAll();

        public Task<IList<ProdutoModel>> FindByNome(string nome);

        public Task<ProdutoModel> FindById(int id);

        public Task<int> Insert(ProdutoModel produtoModel);

        public void Update(ProdutoModel produtoModel);

        public void Delete(ProdutoModel produtoModel);

        public void Delete(int id);

    }
}