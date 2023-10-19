using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Fiap.Api.Donation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AcessoController : ControllerBase
    {

        [HttpGet]
        [Route("Anonimo")]
        [AllowAnonymous]
        public string Anonimo()
        {
            return "Anonimo";
        }

        [HttpGet]
        [Route("Autenticado")]
        public string Autenticado()
        {
            return "Autenticado";
        }

        [HttpGet]
        [Route("admin")]
        [Authorize(Roles = "admin")]
        public string Admin()
        {
            return "Admin";
        }


        [HttpGet]
        [Route("Operador")]
        [Authorize(Roles = "admin, operador")]
        public string Operador()
        {
            return "Operador";
        }

        [HttpGet]
        [Route("revisor")]
        [Authorize(Roles = "admin, operador, revisor")]
        public string Revisor()
        {
            int? userId = 0;
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userIdClaim = identity.FindFirst("UsuarioId");
                if (userIdClaim != null && userIdClaim.Value != null)
                {
                    userId = Int16.Parse(userIdClaim.Value);
                }
            }

            return "Revisor";
        }

    }
}