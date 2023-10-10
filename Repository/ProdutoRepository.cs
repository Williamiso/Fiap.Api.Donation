using Fiap.Api.Donation.Data;
using Fiap.Api.Donation.Models;
using Fiap.Api.Donation.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Donation.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext dataContext;

        public ProdutoRepository(DataContext ctx)
        {
            dataContext = ctx;
        }

        public async Task<IList<ProdutoModel>> FindAll()
        {
            var produtos = dataContext.Produtos.ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }


        public async Task<IList<ProdutoModel>> FindByNome(string nome)
        {
            var produtos = dataContext
                                .Produtos // SELECT * FROM Produtos
                                .Include(p => p.TipoProduto) // INNER JOIN
                                .Where(p => p.Nome.ToLower().Contains(nome.ToLower()))
                                    .ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }

        public async Task<ProdutoModel> FindById(int id)
        {
            var produto = dataContext.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            return produto;
        }

        // Inserir
        public async Task<int> Insert(ProdutoModel produtoModel)
        {
            dataContext.Produtos.Add(produtoModel);
            dataContext.SaveChanges();

            return produtoModel.ProdutoId;
        }

        public async void Update(ProdutoModel produtoModel)
        {
            dataContext.Produtos.Update(produtoModel);
            dataContext.SaveChanges();
        }

        public async void Delete(ProdutoModel produtoModel)
        {
            dataContext.Produtos.Remove(produtoModel);
            dataContext.SaveChanges();
        }


        public async void Delete(int id)
        {
            var produtoModel = new ProdutoModel()
            {
                ProdutoId = id,
            };

            Delete(produtoModel);
        }


    }
}