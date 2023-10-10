using Fiap.Api.Donation.Models;

namespace Fiap.Api.Donation.Repository.Interface
{
    public interface ITipoProdutoRepository
    {

        public Task<IList<TipoProdutoModel>> FindAll();

        public Task<TipoProdutoModel> FindById(int id);

        public Task<int> Insert(TipoProdutoModel tipoModel);

        public void Update(TipoProdutoModel tipoModel);

        public void Delete(TipoProdutoModel tipoModel);

        public void Delete(int id);


    }
}
