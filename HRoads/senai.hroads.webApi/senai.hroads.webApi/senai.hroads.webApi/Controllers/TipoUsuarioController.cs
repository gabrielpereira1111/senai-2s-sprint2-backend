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
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }
        /// <summary>
        /// Listar tipos de usuário
        /// </summary>
        /// <returns>Um Status Code 200 - OK</returns>
        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoUsuarioRepository.ListarTudo());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
        /// <summary>
        /// Buscar por um tipo de usuário
        /// </summary>
        /// <param name="id">Id do tipo de usuário</param>
        /// <returns>Status Code 200 - OK</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult GetById(int id) 
        {
            try
            {
                return Ok(_tipoUsuarioRepository.BuscarPorID(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
        /// <summary>
        /// Cadastrar um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Credenciais do novoTipoUsuario</param>
        /// <returns>Status Code 201 - Created</returns>
        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Post(TipoUsuario novoTipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                
            }
        }
        /// <summary>
        /// Deletar um tipoUsuario
        /// </summary>
        /// <param name="id">id do tipoUsuario que será deletado</param>
        /// <returns>Status Code 204 - NoContent</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Delete(int id)
        {
            try
            {
                _tipoUsuarioRepository.Delete(id);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                
            }
        }
        /// <summary>
        /// Atualizar um tipoUsuario
        /// </summary>
        /// <param name="id">id do tipoUsuario que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Credenciais do tipoUsuarioAtualizado</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Update(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            try
            {
                _tipoUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                
            }
        }
    }
}
