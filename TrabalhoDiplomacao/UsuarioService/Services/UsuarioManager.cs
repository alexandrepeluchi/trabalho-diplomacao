using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UsuarioService.Database.Entities;
using UsuarioService.Helpers;

namespace UsuarioService.Services
{
    public class UsuarioManager : IUsuarioManager
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<Usuario> _users = new List<Usuario>
        {
            new Usuario { UsuarioId = 1, Nome = "Admin", Sobrenome = "Usuario", Username = "admin", Password = "admin", Role = Role.Admin },
            new Usuario { UsuarioId = 2, Nome = "Normal", Sobrenome = "Usuario", Username = "user", Password = "user", Role = Role.User }
        };

        private readonly AppSettings _appSettings;

        public UsuarioManager(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public Usuario Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Segredo);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UsuarioId.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
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
            return _users.WithoutPasswords();
        }

        public Usuario GetById(int id)
        {
            var user = _users.FirstOrDefault(x => x.UsuarioId == id);
            return user.WithoutPassword();
        }
    }
}
