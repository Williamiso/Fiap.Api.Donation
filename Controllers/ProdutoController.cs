using Fiap.Api.Donation.Models;
using Fiap.Api.Donation.Repository.Interface;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Donation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository produtoRepository;

        public ProdutoController(IProdutoRepository _produtoRepository)
        {
            produtoRepository = _produtoRepository;
        }

        // GET: api/Produto
        [HttpGet]
        public async Task<ActionResult<IList<ProdutoModel>>> GetProdutos()
        {
            var produtos = await produtoRepository.FindAll();
            if (produtos == null || produtos.Count == 0)
            {
                return NoContent();
            }

            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel>> GetProdutoModel(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            else
            {
                var prod = await produtoRepository.FindById(id);

                if (prod == null)
                {
                    return NotFound(id);
                }
                else
                {
                    return Ok(prod);
                }
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdutoModel(int id, ProdutoModel produtoModel)
        {
            if (id != produtoModel.TipoProdutoId)
            {
                return BadRequest();
            }
            else
            {
                var produtoConsulta = await produtoRepository.FindById(id);

                if (produtoConsulta == null)
                {
                    return NotFound();
                }
                else
                {
                    produtoRepository.Update(produtoConsulta);
                    return NoContent();
                }
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> PostProdutoModel(ProdutoModel produtoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                await produtoRepository.Insert(produtoModel);

                var url = Request.GetEncodedUrl().EndsWith("/") ?
                                                Request.GetEncodedUrl() :
                                                Request.GetEncodedUrl() + "/";

                var location = new Uri(url + produtoModel.ProdutoId);

                return Created(location, produtoModel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Produto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdutoModel(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var produto = await produtoRepository.FindById(id);

            if (produto == null)
            {
                return NotFound();
            }
            else
            {
                produtoRepository.Delete(id);
                return NoContent();
            }
        }


    }
}