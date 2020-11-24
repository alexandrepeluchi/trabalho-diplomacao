using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PedidoService.Database.Entities;
using PedidoService.Models.Preparos;
using PedidoService.Services;
using PedidoService.Services.Preparos;
using UsuarioService.Database.Entities;

namespace PedidoService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreparoController : ControllerBase
    {
        ApplicationDbContext db;
        private IPreparoManager _preparoManager;
        private readonly IMapper _mapper;

        public PreparoController(IPreparoManager preparoManager,
                                 IMapper mapper)
        {
            db = new ApplicationDbContext();
            _preparoManager = preparoManager;
            _mapper = mapper;
        }

        [Authorize(Roles = Roles.AdminGerenteOuAtendente)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var preparos = _preparoManager.BuscaTodos();

            if (preparos.Count() > 0)
            {
                var preparoDTO = _mapper.Map<List<BuscaPreparoBindingModel>>(preparos);

                return Ok(preparoDTO);
            }

            return NotFound(new { message = "Não existe nenhum Preparo cadastrado." });
        }

        [Authorize(Roles = Roles.AdminGerenteOuAtendente)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var preparo = _preparoManager.BuscaPorId(id);

            if (preparo == null)
                return BadRequest(new { message = "Preparo não foi encontrado!" });

            var preparoDTO = _mapper.Map<PreparoBindingModel>(preparo);

            return Ok(preparoDTO);
        }

        [Authorize(Roles = Roles.AdminGerenteOuAtendente)]
        [HttpPost]
        public IActionResult Post([FromBody] CriaPreparoBindingModel model)
        {
            var preparoDTO = _mapper.Map<Preparo>(model);

            try
            {
                db.Preparos.Add(preparoDTO);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [Authorize(Roles = Roles.AdminGerenteOuAtendente)]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AtualizaPreparoBindingModel model)
        {
            var preparo = _preparoManager.BuscaPorId(id);

            if (preparo == null)
                return BadRequest(new { message = "Preparo não foi encontrado!" });

            var preparoDTO = _mapper.Map<Preparo>(model);

            var preparoAtualizado = _preparoManager.Atualiza(preparoDTO);

            if (preparoAtualizado == null)
            {
                return NotFound("Preparo não foi encontrado!");
            }

            return Ok(preparoAtualizado);
        }

        [Authorize(Roles = Roles.AdminGerenteOuAtendente)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var preparo = _preparoManager.BuscaPorId(id);

            if (preparo == null)
                return BadRequest(new { message = "Preparo não foi encontrado!" });

            var foiExcluido = _preparoManager.Exclui(preparo);

            if (!foiExcluido)
            {
                return NotFound("Erro ao excluir. Preparo não encontrado.");
            }

            return Ok("Preparo excluído com sucesso.");
        }
    }
}
