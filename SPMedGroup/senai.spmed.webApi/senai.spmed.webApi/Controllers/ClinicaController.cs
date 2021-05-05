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
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository { get; set; }

        public ClinicaController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        /// <summary>
        /// Listar todas as clínicas
        /// </summary>
        /// <returns>Retorna uma lista de clínicas e um Status Code 200 - Ok</returns>
        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_clinicaRepository.ListarTudo());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca uma clínica através de seu Id
        /// </summary>
        /// <param name="id">Id da clínica buscada</param>
        /// <returns>Retorna uma clínica e um Status Code 200 - Ok</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_clinicaRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra uma nova clínica
        /// </summary>
        /// <param name="novaClinica">Dados da nova clínica</param>
        /// <returns>Status Code 201 - Created</returns>
        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Post(Clinica novaClinica)
        {
            try
            {
                _clinicaRepository.Cadastrar(novaClinica);
                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta uma clínica
        /// </summary>
        /// <param name="id">Id da clínica que será deletada</param>
        /// <returns>Status Code 204 - NoContent</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Delete(int id)
        {
            try
            {
                _clinicaRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Atualiza os dados de uma clínica
        /// </summary>
        /// <param name="id">Id da clínica</param>
        /// <param name="clinicaAtualizada">Dados da clínica</param>
        /// <returns>Status Code 204 - NoContent</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Put(int id, Clinica clinicaAtualizada)
        {
            try
            {
                _clinicaRepository.Atualizar(id, clinicaAtualizada);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
