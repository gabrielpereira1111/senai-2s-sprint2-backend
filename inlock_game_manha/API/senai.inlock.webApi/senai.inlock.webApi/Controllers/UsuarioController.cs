using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
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
        /// Lista todos os usuários
        /// </summary>
        /// <returns> Lista de usuários</returns>
        [Authorize(Roles ="1")]
        [HttpGet]
        public IActionResult Get()
        {
            List<UsuarioDomain> listaUsuario = _usuarioRepository.ListarTodos();
            return Ok(listaUsuario);
        }
        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario"> novo usuário cadastrado</param>
        /// <returns> Status Code 201(Created)</returns>
        [Authorize(Roles ="1")]
        [HttpPost]
        public IActionResult Cadastrar(UsuarioDomain novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);
            return StatusCode(201);
        }


        /// <summary>
        /// Faz o login
        /// </summary>
        /// <param name="login">credenciais para login</param>
        /// <returns>Token</returns>
        [HttpPost("Login")]
        public IActionResult Login(UsuarioDomain login)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.Login(login.email, login.senha);
            if (usuarioBuscado == null)
            {
                return NotFound("email ou senha inválidos");

            }

            //Payload
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.idTipoUsuario.ToString()),

            };

            //Signature
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("key-usuario-inlock"));

            //Credenciais do token
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    issuer: "inlock.webApi",
                    audience: "inlock.webApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
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
