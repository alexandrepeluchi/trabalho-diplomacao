using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PedidoService.Database.Entities;

namespace PedidoService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        ApplicationDbContext db;
        public PedidoController()
        {
            db = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<Pedido> GetAll()
        {
            return db.Pedidos.ToList();
        }

        // GET api/<PedidoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PedidoController>
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
