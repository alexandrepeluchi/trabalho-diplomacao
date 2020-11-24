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
using PedidoService.Models.Produtos;
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
        private readonly IProdutoManager _produtoManager;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoManager produtoManager,
                                 IMapper mapper)
        {
            db = new ApplicationDbContext();
            _produtoManager = produtoManager;
            _mapper = mapper;
        }

        [Authorize(Roles = Roles.AdminOuGerente)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var produtos = _produtoManager.BuscaTodos();

            if (produtos.Count() > 0)
            {
                var produtoDTO = _mapper.Map<List<BuscaProdutoBindingModel>>(produtos);

                return Ok(produtoDTO);
            }

            return NotFound(new { message = "Não existe nenhum Produto cadastrado." });
        }

        [Authorize(Roles = Roles.AdminOuGerente)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var produto = _produtoManager.BuscaPorId(id);

            if (produto == null)
                return BadRequest(new { message = "Produto não foi encontrado!" });

            var produtoDTO = _mapper.Map<BuscaProdutoBindingModel>(produto);

            return Ok(produtoDTO);
        }

        [Authorize(Roles = Roles.AdminOuGerente)]
        [HttpPost]
        public IActionResult Post([FromBody] CriaProdutoBindingModel model)
        {
            try
            {
                var produtoDTO = _mapper.Map<Produto>(model);

                db.Produtos.Add(produtoDTO);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [Authorize(Roles = Roles.AdminOuGerente)]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AtualizaProdutoBindingModel model)
        {
            var produto = _produtoManager.BuscaPorId(id);

            if (produto == null)
                return BadRequest(new { message = "Produto não foi encontrado!" });

            var produtoDTO = _mapper.Map<Produto>(model);

            var produtoAtualizado = _produtoManager.Atualiza(produtoDTO);

            if (produtoAtualizado == null)
            {
                return NotFound("Produto não foi encontrado!");
            }

            return Ok(produtoAtualizado);
        }

        [Authorize(Roles = Roles.AdminOuGerente)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = _produtoManager.BuscaPorId(id);

            if (produto == null)
                return BadRequest(new { message = "Produto não foi encontrado!" });

            var foiExcluido = _produtoManager.Exclui(produto);

            if (!foiExcluido)
            {
                return NotFound("Erro ao excluir. Produto não encontrado.");
            }

            return Ok("Produto excluído com sucesso.");
        }
    }
}
