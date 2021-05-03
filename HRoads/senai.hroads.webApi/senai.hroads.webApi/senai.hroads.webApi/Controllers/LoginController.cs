using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using senai.hroads.webApi.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
       
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                //Objeto do tipo usuário que recebe o método login, passando como parâmetros o email e senha
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                //Se o email e a senha não sejam encontrados
                if (usuarioBuscado == null)
                {
                    //Retorna um status code NotFound com a uma mensagem personalizada 
                    return NotFound("Email ou senha inválidos!");
                }

                //Se o usuarioBuscado for encontrado, gerar o token:
                //Declara o contéudo do corpo do token - Payload:
                var claim = new[]
                {
                    //Contem o email do usuarioBuscado:
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    //Contem o id do usuarioBuscado
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuarios.ToString()),
                    //Contem o id do tipo de usuário
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString())
                };

                //Define a chave de acesso do token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao"));

                //Define as credenciais do token
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //Gera o token
                var token = new JwtSecurityToken(
                    issuer:                     "inlock.webApi",                //Emissor do Token
                    audience:                   "inlock.webApi",                //Destinatário
                    expires:                    DateTime.Now.AddMinutes(30),    //Intervalo de tempo em que o token permanecerá válido
                    claims:                     claim,                          //Conteúdo da Payload
                    signingCredentials:         creds                           //Credenciais do token
                    );

                //Retorna o Status Code 200 junto com o token gerado
                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    }
                    );
               
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
