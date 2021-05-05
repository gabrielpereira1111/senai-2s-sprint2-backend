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
    }
}
