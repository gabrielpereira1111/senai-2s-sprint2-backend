using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_filmes_WebApi.Domain;
using senai_filmes_WebApi.Interface;
using senai_filmes_WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_filmes_WebApi.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        
        }

        /// <summary>
        /// Fazer o login
        /// </summary>
        /// <param name="login">Credenciais necessárias para fazer login</param>
        /// <returns>Token</returns>
        [HttpPost]
        public IActionResult Login(UsuarioDomain login)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.Login(login.email, login.senha);

            if (usuarioBuscado == null)
            {
                return NotFound("Email ou senha inválidas!");
            }

            //Payload
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.tipoUsuario),
                new Claim("<Tipo da Claim>", "<Nome da Claim>")
            };

            //Signature
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao"));

            //Credenciais do token
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    issuer: "Filmes.webApi",                    //Emissor
                    audience: "Filmes.webApi",                  //Destinatário
                    claims: claims,                             //Dados Definidos
                    expires: DateTime.Now.AddMinutes(30),       //Intervalo de tempo que o token é válido
                    signingCredentials: creds                   //credenciais de codificação do token
                
                );



            return Ok
                (
                new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                }
                );
            
        }
    }
}
