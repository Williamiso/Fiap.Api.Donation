using Fiap.Api.Donation.Models;

namespace Fiap.Api.Donation.Repository.Interface
{
    public interface ITrocaRepository
    {

        public Guid Insert(Models.TrocaModel trocaModel);

        public TrocaModel FindById(Guid id);

    }
}