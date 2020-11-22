using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuarioService.Database;
using UsuarioService.Database.Entities;
using UsuarioService.Models;
using UsuarioService.Models.Usuarios;
using UsuarioService.Services;
using UsuarioService.Validacao.Usuarios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsuarioService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        ApplicationDbContext _dbContext;
        private readonly IUsuarioManager _usuarioManager;
        private readonly IUsuarioValidador _usuarioValidador;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioManager usuarioManager,
                                 IUsuarioValidador usuarioValidador,
                                 IMapper mapper)
        {
            _dbContext = new ApplicationDbContext();
            _usuarioManager = usuarioManager;
            _usuarioValidador = usuarioValidador;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var user = _usuarioManager.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Usuário ou Senha incorreto!" });

            return Ok(user);
        }

        [Authorize(Roles = Roles.AdminOuGerente)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var usuarios = _usuarioManager.GetAll();

            if (usuarios.Count() > 0)
            {
                var usuariosDTO = _mapper.Map<List<UsuarioOutputDTO>>(usuarios);

                return Ok(usuariosDTO);
            }

            return NotFound(new { message = "Não existe nenhum Caixa cadastrado." });
        }

        [Authorize(Roles = Roles.AdminOuGerente)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var usuario = _usuarioManager.BuscaPorId(id);

            if (usuario == null)
                return BadRequest(new { message = "Usuário não foi encontrado!" });

            var usuarioDTO = _mapper.Map<UsuarioBindingModel>(usuario);

            return Ok(usuarioDTO);
        }

        [Authorize(Roles = Roles.AdminOuGerente)]
        [HttpPost]
        public IActionResult Post([FromBody] CriaUsuarioBindingModel model)
        {
            var usuarioDTO = _mapper.Map<Usuario>(model);

            _usuarioValidador.ValidaRegrasDeNegocio(usuarioDTO);

            try
            {
                _dbContext.Usuarios.Add(usuarioDTO);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [Authorize(Roles = Roles.AdminOuGerente)]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AtualizaUsuarioBindingModel model)
        {
            var usuario = _usuarioManager.BuscaPorId(id);

            if (usuario == null)
                return BadRequest(new { message = "Usuário não foi encontrado!" });

            var usuarioDTO = _mapper.Map<Usuario>(model);

            _usuarioValidador.ValidaRegrasDeNegocio(usuarioDTO);

            var usuarioAtualizado = _usuarioManager.Atualiza(usuarioDTO);

            if (usuarioAtualizado == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            return Ok(usuarioAtualizado);
        }

        [Authorize(Roles = Roles.AdminOuGerente)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _usuarioManager.BuscaPorId(id);

            if (usuario == null)
                return BadRequest(new { message = "Usuário não foi encontrado!" });

            var foiExcluido = _usuarioManager.Exclui(usuario);

            if (!foiExcluido)
            {
                return NotFound("Erro ao excluir. Usuário não encontrado.");
            }
            
            return Ok("Usuário excluído com sucesso.");
        }
    }
}
