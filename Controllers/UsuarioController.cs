using AutoMapper;
using Fiap.Api.Donation.Models;
using Fiap.Api.Donation.Repository.Interface;
using Fiap.Api.Donation.Service;
using Fiap.Api.Donation.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Donation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository usuarioRepository;

        private readonly IMapper mapper;

        public UsuarioController(IUsuarioRepository _usuarioRepository, IMapper _mapper)
        {
            usuarioRepository = _usuarioRepository;
            mapper = _mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IList<UsuarioResponseVM>>> Get()
        {
            var usuarios = await usuarioRepository.FindAll();
            if (usuarios == null || usuarios.Count == 0)
            {
                return NoContent();
            }
            else
            {
                var resposta = mapper.Map<List<UsuarioResponseVM>>(usuarios);
                return Ok(resposta);
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<UsuarioResponseVM> Get(int id)
        {
            var usuario = usuarioRepository.FindById(id);
            if (usuario == null || usuario.UsuarioId == 0)
            {
                return NotFound();
            }
            else
            {
                var resposta = mapper.Map<UsuarioResponseVM>(usuario);
                return Ok(resposta);
            }
        }

        [HttpPost]
        public ActionResult<UsuarioModel> Post([FromBody] UsuarioModel usuarioModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                usuarioRepository.Insert(usuarioModel);

                var url = Request.GetEncodedUrl().EndsWith("/") ?
                                                Request.GetEncodedUrl() :
                                                Request.GetEncodedUrl() + "/";

                var location = new Uri(url + usuarioModel.UsuarioId);


                return Created(location, usuarioModel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<UsuarioModel> Put([FromRoute] int id, [FromBody] UsuarioModel usuarioModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (id != usuarioModel.UsuarioId)
            {
                return NotFound();
            }


            usuarioRepository.Update(usuarioModel);

            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public ActionResult<int> Delete([FromRoute] int id)
        {

            if (id == 0)
            {
                return BadRequest();
            }

            var usuarioModel = usuarioRepository.FindById(id);

            if (usuarioModel == null)
            {
                return NotFound();
            }
            else
            {
                usuarioRepository.Delete(id);
                return NoContent();
            }

        }


        [HttpPost]
        [Route("Login")]
        public ActionResult<LoginResponseVM> Login([FromBody] LoginRequestVM loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var usuarioModel = mapper.Map<UsuarioModel>(loginRequest);
            var usuario = usuarioRepository.FindByEmailAndSenha(usuarioModel);

            if (usuario != null)
            {
                var response = mapper.Map<LoginResponseVM>(usuario);
                response.Token = AuthenticationService.GetToken(usuario);

                return Ok(response);
            }
            else
            {
                return NotFound();
            }

        }



    }
}