using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_czbooks_api.Domains;
using senai_czbooks_api.Interfaces;
using senai_czbooks_api.Repositories;
using senai_czbooks_api.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_czbooks_api.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuario { get; set; }

        public LoginController()
        {
            _usuario = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Logar(LoginViewModel Logarr)
        {
            Usuario usuariologin = _usuario.Login(Logarr.Email, Logarr.Senha);

            if (usuariologin == null)
            {
                return BadRequest("Login ou senha incorreto.");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuariologin.Email),

                new Claim(JwtRegisteredClaimNames.Jti, usuariologin.IdUsuario.ToString()),

                new Claim(ClaimTypes.Role, usuariologin.IdTipoUsuario.ToString()),

                new Claim("role", usuariologin.IdTipoUsuario.ToString()),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("senai_czbooks-chave-autenticacao"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                   issuer: "senai_czbooks_api.webApi",                 // emissor do token
                   audience: "senai_czbooks_api.webApi",               // destinatário do token
                   claims: claims,                        // dados definidos acima
                   expires: DateTime.Now.AddMinutes(30),  // tempo de expiração
                   signingCredentials: creds              // credenciais do token
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }

    }
}
