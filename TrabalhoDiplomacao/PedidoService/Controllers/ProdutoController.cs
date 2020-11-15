using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PedidoService.Database.Entities;
using PedidoService.Models;
using PedidoService.Services.Produtos;
using UsuarioService.Database.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PedidoService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        ApplicationDbContext db;
        private IProdutoManager _produtoManager;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoManager produtoManager,
                                 IMapper mapper)
        {
            db = new ApplicationDbContext();
            _produtoManager = produtoManager;
            _mapper = mapper;
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        public IEnumerable<Produto> GetAll()
        {
            return db.Produtos.ToList();
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var produto = _produtoManager.BuscaPorId(id);

            if (produto == null)
                return BadRequest(new { message = "Produto não foi encontrado!" });

            var produtoDTO = _mapper.Map<ProdutoDTO>(produto);

            return Ok(produtoDTO);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Produto model)
        {
            try
            {
                db.Produtos.Add(model);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
