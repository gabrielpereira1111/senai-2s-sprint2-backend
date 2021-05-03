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
    public class PersonagemController : ControllerBase
    {
        private IPersonagemRepository _personagemRepository { get; set; }

        public PersonagemController()
        {
            _personagemRepository = new PersonagemRepository();
        }

        /// <summary>
        /// Listar todos os personagens
        /// </summary>
        /// <returns>Lista de todos os personagens</returns>
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                return Ok(_personagemRepository.ListarTudo());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Buscar um personagem a partir de seu Id
        /// </summary>
        /// <param name="id">Id do personagem que será buscado</param>
        /// <returns>Personagem buscado</returns>
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_personagemRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastrar um novo personagem
        /// </summary>
        /// <param name="novoPersonagem">Credenciais do novo personagem</param>
        /// <returns>Status Code 201 - Created</returns>
        [HttpPost]
        [Authorize(Roles = "2")]
        public IActionResult Post(Personagem novoPersonagem)
        {
            try
            {
                _personagemRepository.Cadastrar(novoPersonagem);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
        }

        /// <summary>
        /// Deleta um personagem
        /// </summary>
        /// <param name="id">Id do personagem que será deletado</param>
        /// <returns>Retorna Status Code 204 - NoContent</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "2")]
        public IActionResult Delete(int id)
        {
            try
            {
                _personagemRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
        }

        /// <summary>
        /// Atualizar um personagem
        /// </summary>
        /// <param name="id">Id do personagem que será atualizado</param>
        /// <param name="personagem">Credenciais atualizadas do personagem</param>
        /// <returns>Retorna um Status Code 204 - NoContent</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "2")]
        public IActionResult Put(int id, Personagem personagem)
        {
            try
            {
                _personagemRepository.Atualizar(id, personagem);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
