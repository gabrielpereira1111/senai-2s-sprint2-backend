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
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _medicoRepository { get; set; }

        public MedicoController()
        {
            _medicoRepository = new MedicoRepository();
        }

        /// <summary>
        /// Lista todos os médicos
        /// </summary>
        /// <returns>Uma lista de médicos junto com um Status Code 201 - Created</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_medicoRepository.ListarTudo());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Buscar por um médico atravéd do Id
        /// </summary>
        /// <param name="id">Id do médico buscado</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_medicoRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra um novo médico
        /// </summary>
        /// <param name="novoMedico">Dados do novo médico</param>
        /// <returns>Retorna um Status Code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Medico novoMedico)
        {
            try
            {
                _medicoRepository.Cadastrar(novoMedico);
                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um médico
        /// </summary>
        /// <param name="id">Id do médico que será deletado</param>
        /// <returns>Retorna Status Code 204 - NoContent</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _medicoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza um médico
        /// </summary>
        /// <param name="id">Id do médico</param>
        /// <param name="medicoAtualizado">Dados atualizados do médico</param>
        /// <returns>Retorna Status Code 204 - NoContent</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Medico medicoAtualizado)
        {
            try
            {
                _medicoRepository.Atualizar(id, medicoAtualizado);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
