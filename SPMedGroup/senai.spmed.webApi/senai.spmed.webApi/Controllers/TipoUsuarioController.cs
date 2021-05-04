using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.spmed.webApi.Domains;
using senai.spmed.webApi.Interfaces;
using senai.spmed.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmed.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository(); 
        }

        /// <summary>
        /// Lista todos os tipod de usuário
        /// </summary>
        /// <returns>Retorna um Status Code 200 - Ok junto com uma lista de tipos de usuários</returns>
        [HttpGet]
        public IActionResult Get() 
        {
            try
            {
                return Ok(_tipoUsuarioRepository.ListarTudo());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca por um tipo de usuário através de seu Id
        /// </summary>
        /// <param name="id">Id do tipo de usuário</param>
        /// <returns>Retorna um usuário junto com um Status Code 200 - OK</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_tipoUsuarioRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Dados do novo tipo de usuário</param>
        /// <returns>Retorna um Status Code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(TiposUsuario novoTipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);
                return StatusCode(201);
            }
            catch (Exception ex) 
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um tipo de usuário
        /// </summary>
        /// <param name="id">Id do tipo de usuário buscado</param>
        /// <returns>Retorna um Status Code 204 - NoContent</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _tipoUsuarioRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        
        /// <summary>
        /// Atualiza um tipo de usuário
        /// </summary>
        /// <param name="id">Id do tipo de usuário que será atualizado</param>
        /// <param name="tipoUsuario">Dados atualizados do tipo de usuário</param>
        /// <returns>Retorna um Status Code 204 - NoContent</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposUsuario tipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Atualizar(id, tipoUsuario);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }

    
}
