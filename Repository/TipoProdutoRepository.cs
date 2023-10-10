using Fiap.Api.Donation.Data;
using Fiap.Api.Donation.Models;
using Fiap.Api.Donation.Repository.Interface;

namespace Fiap.Api.Donation.Repository
{
    public class TipoProdutoRepository : ITipoProdutoRepository
    {
       
            private readonly DataContext dataContext;

            public TipoProdutoRepository(DataContext ctx)
            {
                dataContext = ctx;
            }


            public async Task<IList<TipoProdutoModel>> FindAll()
            {
                var tipos = dataContext.TipoProdutos.ToList();

                return tipos == null ? new List<TipoProdutoModel>() : tipos;
            }

            public async Task<TipoProdutoModel> FindById(int id)
            {
                var tipo = dataContext.TipoProdutos.FirstOrDefault(t => t.TipoProdutoId == id);

                return tipo;
            }

            public async Task<int> Insert(TipoProdutoModel tipoModel)
            {
                dataContext.TipoProdutos.Add(tipoModel);
                dataContext.SaveChanges();

                return tipoModel.TipoProdutoId;
            }

            // Alterar
            public async void Update(TipoProdutoModel tipoModel)
            {
                dataContext.TipoProdutos.Update(tipoModel);
                dataContext.SaveChanges();
            }

            // Excluir
            public async void Delete(TipoProdutoModel tipoModel)
            {
                dataContext.TipoProdutos.Remove(tipoModel);
                dataContext.SaveChanges();
            }


            public async void Delete(int id)
            {
                var tipoModel = new TipoProdutoModel()
                {
                    TipoProdutoId = id,
                };

                Delete(tipoModel);
            }
        }
    }

