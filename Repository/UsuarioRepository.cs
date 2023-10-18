using Fiap.Api.Donation.Data;
using Fiap.Api.Donation.Models;
using Fiap.Api.Donation.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Donation.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly DataContext dataContext;

        public UsuarioRepository(DataContext ctx)
        {
            dataContext = ctx;
        }


        public UsuarioModel FindByEmailAndSenha(UsuarioModel usuarioModel)
        {
            var usuario = dataContext
                    .Usuarios
                    .AsNoTracking()
                    .FirstOrDefault(u => u.Senha.Equals(usuarioModel.Senha) &&
                                          u.EmailUsuario.Equals(usuarioModel.EmailUsuario));

            return usuario;
        }

        public async Task<IList<UsuarioModel>> FindAll()
        {
            return dataContext.Usuarios.AsNoTracking().ToList();
        }


        public void Delete(int id)
        {
            var usuarioModel = new UsuarioModel()
            {
                UsuarioId = id
            };

            dataContext.Usuarios.Remove(usuarioModel);
            dataContext.SaveChanges();
        }



        public UsuarioModel FindById(int id)
        {
            var usuario = dataContext
                    .Usuarios
                    .AsNoTracking()
                    .FirstOrDefault(u => u.UsuarioId == id);

            return usuario;
        }

        public int Insert(UsuarioModel usuarioModel)
        {
            dataContext.Usuarios.AddAsync(usuarioModel);
            dataContext.SaveChangesAsync();
            return usuarioModel.UsuarioId;
        }

        public void Update(UsuarioModel usuarioModel)
        {
            dataContext.Usuarios.Update(usuarioModel);
            dataContext.SaveChanges();
        }


    }
}