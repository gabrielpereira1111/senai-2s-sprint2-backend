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
    public class TipoHabilidadeController : ControllerBase
    {
        ITipoHabilidadeRepository _tipoHabilidadeRepository { get; set; }
        public TipoHabilidadeController()
        {
            _tipoHabilidadeRepository = new TipoHabilidadeRepository();
        }

        /// <summary>
        /// Listar os tipos da habilidade
        /// </summary>
        /// <returns>Status Code 200 - OK</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoHabilidadeRepository.ListarTudo());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Buscar um tipo de habilidade a partir do seu Id
        /// </summary>
        /// <param name="id">id do tipo de habilidade que será buscado</param>
        /// <returns>Status Code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                TiposHabilidade tipoHabBuscado = _tipoHabilidadeRepository.BuscarPorId(id);
                return Ok(tipoHabBuscado);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastrar novo tipo de habilidade
        /// </summary>
        /// <param name="novoTipoHabilidade">Credenciais do novo tipo de habilidade</param>
        /// <returns>Status Code 201 - Created</returns>
        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Post(TiposHabilidade novoTipoHabilidade)
        {
            try
            {
                _tipoHabilidadeRepository.Cadastrar(novoTipoHabilidade);
                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta um tipo de habilidade
        /// </summary>
        /// <param name="id">id do tipo de habilidade que será deletado</param>
        /// <returns>Status Code 204 - NoContent</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _tipoHabilidadeRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Atualiza um tipo de habilidade
        /// </summary>
        /// <param name="id">id do tipo de habilidade que será atualizado</param>
        /// <param name="tipoHabAtualizado">Credenciais atualizadas do tipoHabilidade</param>
        /// <returns>Status Code 204 - NoContent</returns>
        [HttpPut("{id}")]
        public IActionResult Update(int id, TiposHabilidade tipoHabAtualizado)
        {
            try
            {
                _tipoHabilidadeRepository.Atualizar(id, tipoHabAtualizado);
                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}
