using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CaixaService.Database;
using CaixaService.Database.Entities;
using CaixaService.Models.Caixas;
using CaixaService.Services.Caixas;
using CaixaService.Validacao.Caixas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuarioService.Database.Entities;

namespace CaixaService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaixaController : ControllerBase
    {
        ApplicationDbContext db;
        private readonly ICaixaManager _caixaManager;
        private readonly ICaixaValidador _caixaValidador;
        private readonly IMapper _mapper;

        public CaixaController(ICaixaManager caixaManager,
                               ICaixaValidador caixaValidador,
                               IMapper mapper)
        {
            db = new ApplicationDbContext();
            _caixaManager = caixaManager;
            _caixaValidador = caixaValidador;
            _mapper = mapper;
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var caixas = _caixaManager.BuscaTodos();

            if (caixas.Count() > 0)
            {
                var caixaDTO = _mapper.Map<List<CaixaOutputDTO>>(caixas);

                return Ok(caixaDTO);
            }

            return NotFound(new { message = "Não existe nenhum Caixa cadastrado." });
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var caixa = _caixaManager.BuscaPorId(id);

            if (caixa == null)
                return BadRequest(new { message = "Caixa não foi encontrado!" });

            var caixaDTO = _mapper.Map<CaixaBindingModel>(caixa);

            return Ok(caixaDTO);
        }

        // POST api/<CaixaController>
        [HttpPost]
        public IActionResult Post([FromBody] CriaCaixaBindingModel model)
        {
            var caixaDTO = _mapper.Map<Caixa>(model);

            _caixaValidador.ValidaRegrasDeNegocio(caixaDTO);

            try
            {
                db.Caixas.Add(caixaDTO);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // PUT api/<CaixaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CaixaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
