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
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository { get; set; }

        public PacienteController()
        {
            _pacienteRepository = new PacienteRepository();
        }

        /// <summary>
        /// Lista todos os pacientes
        /// </summary>
        /// <returns>Uma lista de pacientes e um Status Code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_pacienteRepository.ListarTudo());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca por um paciente através de seu Id
        /// </summary>
        /// <param name="id">Id do paciente buscado</param>
        /// <returns>Retorna um paciente buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_pacienteRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                
            }
        }


        /// <summary>
        /// Cadastra um novo paciente
        /// </summary>
        /// <param name="novoPaciente">Dados do novo paciente</param>
        /// <returns>Status Code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Paciente novoPaciente)
        {
            try
            {
                _pacienteRepository.Cadastrar(novoPaciente);
                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um paciente
        /// </summary>
        /// <param name="id">Id do paciente que será deletado</param>
        /// <returns>Status Code 204 - NoContent</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _pacienteRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza um paciente
        /// </summary>
        /// <param name="id">Id do paciente</param>
        /// <param name="paciente">Dados atualizados do paciente</param>
        /// <returns>Status Code 204 - NoContent</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Paciente paciente)
        {
            try
            {
                _pacienteRepository.Atualizar(id, paciente);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

    }
}
