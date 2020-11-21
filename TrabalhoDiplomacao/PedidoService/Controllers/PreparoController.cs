using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PedidoService.Database.Entities;
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

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var preparos = _preparoManager.BuscaTodos();

            if (preparos.Count() > 0)
            {
                return Ok(preparos);
            }

            return NotFound(new { message = "Não existe nenhum Preparo cadastrado." });
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var preparo = _preparoManager.BuscaPorId(id);

            if (preparo == null)
                return BadRequest(new { message = "Preparo não foi encontrado!" });

            return Ok(preparo);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        public IActionResult Post([FromBody] Preparo model)
        {
            try
            {
                db.Preparos.Add(model);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // PUT api/<PreparoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PreparoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
