using Fiap.Api.Donation.Models;

namespace Fiap.Api.Donation.Repository.Interface
{
    public interface IUsuarioRepository
    {
        public UsuarioModel FindByEmailAndSenha(UsuarioModel usuarioModel);
        public void Delete(int id);
        public Task<IList<UsuarioModel>> FindAll();
        public UsuarioModel FindById(int id);
        public int Insert(UsuarioModel usuarioModel);
        public void Update(UsuarioModel usuarioModel);
    }
}