using Microsoft.AspNetCore.Authorization;
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
    public class EspecialidadeController : ControllerBase
    {
        private IEspecialidadeRepository _especialidadeRepository { get; set; }

        public EspecialidadeController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }

        /// <summary>
        /// Lista todos as especialidades
        /// </summary>
        /// <returns>Retorna uma lista junto com um Status Code 201 - Ok</returns>
        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_especialidadeRepository.ListarTudo());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca por uma especialidade através de um Id
        /// </summary>
        /// <param name="id">Id da especialidade</param>
        /// <returns>Status Code 201 - Ok</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_especialidadeRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra uma nova especialidade
        /// </summary>
        /// <param name="novaEspecialidade">Dados da nova especialidade</param>
        /// <returns>Status Code 201 - Created</returns>
        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Post(Especialidade novaEspecialidade)
        {
            try
            {
                _especialidadeRepository.Cadastrar(novaEspecialidade);
                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta uma especialidade
        /// </summary>
        /// <param name="id">Id da especialidade</param>
        /// <returns>Status Code 204 - NoContent</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Delete(int id)
        {
            try
            {
                _especialidadeRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza uma especialidade
        /// </summary>
        /// <param name="id">Id da especialidade</param>
        /// <param name="especialidadeAtualizada">Dados atualizados da especialidade</param>
        /// <returns>Status Code 204 - NoContent</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Put(int id, Especialidade especialidadeAtualizada)
        {
            try
            {
                _especialidadeRepository.Atualizar(id, especialidadeAtualizada);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
