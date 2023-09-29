using Fiap.Api.Donation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Donation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProdutoController : ControllerBase
    {
        [HttpGet]
        public IList<TipoProdutoModel> Get()
        {
            return new List<TipoProdutoModel>()
            {
                new TipoProdutoModel()
                {
                    TipoProdutoId = 1,
                    Nome = "Celular"
                },
                new TipoProdutoModel() {
                    TipoProdutoId = 2,
                    Nome = "Televisor"
                }
            };
        }

        [HttpGet("{id:int}")]
        public TipoProdutoModel Get([FromRoute] int id)
        {
            return new TipoProdutoModel()
            {
                TipoProdutoId = 1,
                Nome = "Celular"
            };
        }
    }
}
