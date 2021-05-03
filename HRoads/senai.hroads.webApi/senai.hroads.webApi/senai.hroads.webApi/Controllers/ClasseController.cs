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
    public class ClasseController : ControllerBase
    {
        private IClasseRepository _classeRepository { get; set; }

        public ClasseController()
        {
            _classeRepository = new ClasseRepository();
        }

        /// <summary>
        /// Lista todas as classes
        /// </summary>
        /// <returns>Lista de todas as classes junto com um Status Code 200 - Ok </returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_classeRepository.ListarTudo());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        /// <summary>
        /// Busca a classe pelo Id
        /// </summary>
        /// <param name="id">Id da classe que será buscada</param>
        /// <returns>Classe</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_classeRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra uma nova classe
        /// </summary>
        /// <param name="novaClasse">Credenciais da nova classe</param>
        /// <returns>Status Code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Classe novaClasse)
        {
            try
            {
                _classeRepository.Cadastrar(novaClasse);
                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta uma classe
        /// </summary>
        /// <param name="id">Id da classe que será deletada</param>
        /// <returns>Status Code 204 - NoContent</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _classeRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza uma classe
        /// </summary>
        /// <param name="id">Id da classe que será atualizada</param>
        /// <param name="classe">Credenciais atualizadas da classe</param>
        /// <returns>Status Code 204 - NoContent</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Classe classe)
        {
            try
            {
                _classeRepository.Atualizar(id, classe);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                
            }
        }
    }
}
