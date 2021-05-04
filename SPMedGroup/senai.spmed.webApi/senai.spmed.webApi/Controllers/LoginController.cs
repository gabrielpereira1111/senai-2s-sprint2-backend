using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.spmed.webApi.Domains;
using senai.spmed.webApi.Interfaces;
using senai.spmed.webApi.Repositories;
using senai.spmed.webApi.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.spmed.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _loginRepository { get; set; }

        public LoginController()
        {
            _loginRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Faz o login do usuário
        /// </summary>
        /// <param name="login">Credenciais necessárias para o login</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuario usuario = _loginRepository.Login(login.Email, login.Senha);

                if (usuario == null)
                {
                    return NotFound("Email ou senha inválidos!");
                }

                //Payload
                var claim = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.Idusuarios.ToString()),
                    new Claim(ClaimTypes.Role, usuario.IdtiposUsuarios.ToString())
                };

                //chave autenticação
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("spmedgroup-chave-autenticacao"));

                //credenciais
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //token
                var token = new JwtSecurityToken
                    (
                        issuer:              "spmed.webApi",
                        audience:            "spmed.webApi",
                        expires:             DateTime.Now.AddMinutes(30),
                        claims:               claim,
                        signingCredentials:  creds
                    );

                //Gerar Token
                return Ok
                    (
                    new 
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    });
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
