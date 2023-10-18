using System.ComponentModel.DataAnnotations;

namespace Fiap.Api.Donation.ViewModel
{
    public class LoginRequestVM
    {

        [Required(ErrorMessage = "Email do usuário é obrigatório!")]
        public string EmailUsuario { get; set; }

        [Required(ErrorMessage = "Email do usuário é obrigatório!")]
        public string Senha { get; set; }


        public LoginRequestVM()
        {

        }

        public LoginRequestVM(string emailUsuario, string senha)
        {
            EmailUsuario = emailUsuario;
            Senha = senha;
        }
    }
}
