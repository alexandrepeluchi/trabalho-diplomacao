using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuarioService.Database;
using UsuarioService.Database.Entities;
using UsuarioService.Models;
using UsuarioService.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsuarioService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        ApplicationDbContext db;
        private IUsuarioManager _usuarioManager;

        public UsuarioController(IUsuarioManager usuarioManager)
        {
            db = new ApplicationDbContext();
            _usuarioManager = usuarioManager;
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

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var usuarios = _usuarioManager.GetAll();
            return Ok(usuarios);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet("{id}")]
        public Usuario Get(int id)
        {
            return db.Usuarios.Find(id);
        }

        [Authorize(Roles = Roles.Admin)]
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
