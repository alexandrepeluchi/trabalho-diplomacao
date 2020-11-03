using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PedidoService.Database.Entities;
using PedidoService.Services;
using UsuarioService.Database.Entities;

namespace PedidoService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        ApplicationDbContext db;
        private IPedidoManager _pedidoManager;

        public PedidoController(IPedidoManager pedidoManager)
        {
            db = new ApplicationDbContext();
            _pedidoManager = pedidoManager;
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        public IEnumerable<Pedido> GetAll()
        {
            return db.Pedidos.ToList();
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var pedido = db.Pedidos.Find(id);

            if (pedido == null)
                return BadRequest(new { message = "Pedido não foi encontrado!" });

            return Ok(pedido);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        public IActionResult Post([FromBody] Pedido model)
        {
            try
            {
                db.Pedidos.Add(model);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
