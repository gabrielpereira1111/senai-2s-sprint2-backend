using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.spmed.webApi.Domains;
using senai.spmed.webApi.Interfaces;
using senai.spmed.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmed.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }

        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Lista todas as consultas de determinado paciente
        /// </summary>
        /// <returns>Retorna a lista de consultas juntos com um Status Code 200 - Ok</returns>
        [HttpGet("consultapaciente")]
        [Authorize(Roles = "2")]
        public IActionResult GetByPatient()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims
                    .First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consultaRepository.listarPacientes(idUsuario));
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as consultas se você não estiver logado!",
                    ex
                });
            }
        }

        /// <summary>
        /// Lista os agendamentos de consulta relacionadas a um médico
        /// </summary>
        /// <returns>Uma lista com um Status Code 200 - Ok</returns>
        [HttpGet("agendamentomedicos")]
        [Authorize(Roles = "3")]
        public IActionResult GetByDoctor()
        {
            try
            {
                int idMedico = Convert.ToInt32(HttpContext.User.Claims
                    .First(m => m.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consultaRepository.listarMedicos(idMedico));

            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as consultas se você não estiver logado!",
                    ex
                });
            }
        }

        /// <summary>
        /// Atualiza a descrição de uma consulta
        /// </summary>
        /// <param name="id">Id da consulta</param>
        /// <param name="descricao">descrição</param>
        /// <returns>Status Code 204 - NoContent</returns>
        [HttpPatch("descricao/{id}")]
        [Authorize(Roles = "3")]
        public IActionResult Patch(int id, Consulta descricao)
        {
            try
            {
                _consultaRepository.descricaoConsulta(id, descricao);
                return NoContent();

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualizar situação da consulta
        /// </summary>
        /// <param name="id">Id da consulta</param>
        /// <param name="situacao">situação da consulta</param>
        /// <returns></returns>
        [HttpPatch("situacao/{id}")]
        [Authorize(Roles = "1")]
        public IActionResult PatchSituation(int id, Consulta situacao)
        {
            try
            {
                _consultaRepository.atualizarSituacao(id, situacao.Situacao);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra uma nova consulta
        /// </summary>
        /// <returns>Status Code 201 - Created</returns>
        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Post(Consulta consulta)
        {
            try
            {


                _consultaRepository.Cadastrar(consulta);
                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta uma consulta
        /// </summary>
        /// <param name="id">Id da consulta</param>
        /// <returns>Um Status Code 204</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Delete(int id)
        {
            try
            {
                _consultaRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza um consulta
        /// </summary>
        /// <param name="id">Id da consulta</param>
        /// <param name="consultaAtualizada">Dados da consulta</param>
        /// <returns>Status Code 204 - NoContent</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Put(int id, Consulta consultaAtualizada)
        {
            try
            {
                _consultaRepository.Atualizar(id, consultaAtualizada);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Lista todas as consultas
        /// </summary>
        /// <returns>Uma lista de consultas e um Status Code 200 - Ok</returns>
        [HttpGet]
        //[Authorize(Roles = "1")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_consultaRepository.ListarTudo());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca por uma consulta através de seu Id
        /// </summary>
        /// <param name="id">Id da consulta</param>
        /// <returns>Uma consulta e um Status Code 200 - Ok</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_consultaRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }

    
}
