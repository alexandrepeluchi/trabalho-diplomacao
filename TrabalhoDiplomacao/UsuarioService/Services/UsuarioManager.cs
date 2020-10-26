using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UsuarioService.Database;
using UsuarioService.Database.Entities;
using UsuarioService.Helpers;
using UsuarioService.Uteis;

namespace UsuarioService.Services
{
    public class UsuarioManager : IUsuarioManager
    {
        private readonly AppSettings _appSettings;
        ApplicationDbContext _dbContext;
        private readonly IUsuarioServico _usuarioServico;

        public UsuarioManager(IOptions<AppSettings> appSettings,
                              IUsuarioServico usuarioServico)
        {
            _appSettings = appSettings.Value;
            _dbContext = new ApplicationDbContext();
            _usuarioServico = usuarioServico;
        }

        public Usuario Authenticate(string username, string password)
        {
            var user = _usuarioServico.BuscaTodos()
                                                .Include(x => x.Role)
                                                .SingleOrDefault(x => x.Username == username && x.Password == password);     

            // Returno null se o usuário não foi encontrado
            if (user == null)
                return null;

            // Autenticação bem-sucedida, então gera Token JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Segredo);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.RoleName.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user.WithoutPassword();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _dbContext.Set<Usuario>().AsNoTracking();
        }

        public Usuario BuscaPorId(int id)
        {
            var user = _usuarioServico.BuscaTodos().FirstOrDefault(x => x.Id == id);
            return user.WithoutPassword();
        }
    }
}
