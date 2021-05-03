using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
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
        /// Listar todos os usuários
        /// </summary>
        /// <returns>Status Code 200 - OK</returns>
        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_usuarioRepository.ListarTudo());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Buscar por um usuário a partir de seu id
        /// </summary>
        /// <param name="id">id do usuário que será buscado</param>
        /// <returns>Status Code 200 - OK</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_usuarioRepository.BuscarPorID(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
        
        /// <summary>
        /// Cadastrar um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Credenciais desse novo usuário</param>
        /// <returns>Status Code 201 - Created</returns>
        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Post(Usuario novoUsuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(novoUsuario);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deletar um usuário
        /// </summary>
        /// <param name="id">Id do usuário que será deletado</param>
        /// <returns>Status Content 204 - No Content</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Delete(int id)
        {
            try
            {
                _usuarioRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Atualizar um usuário
        /// </summary>
        /// <param name="id">Id do usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">Credenciais atualizadas do usuário</param>
        /// <returns>Status Code 204 - No Content</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Update(int id, Usuario usuarioAtualizado)
        {
            try
            {
                _usuarioRepository.Atualizar(id, usuarioAtualizado);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
