using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuarioService.Database;
using UsuarioService.Database.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsuarioService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        ApplicationDbContext db;

        public UsuarioController()
        {
            db = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return db.Usuarios.ToList();
        }

        [HttpGet("{id}")]
        public Usuario Get(int id)
        {
            return db.Usuarios.Find(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Usuario model)
        {
            try
            {
                db.Usuarios.Add(model);
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
