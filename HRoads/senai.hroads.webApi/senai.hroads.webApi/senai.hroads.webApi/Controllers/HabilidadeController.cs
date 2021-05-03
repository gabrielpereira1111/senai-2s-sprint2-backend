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
    public class HabilidadeController : ControllerBase
    {
        private IHabilidadeRepository _habilidadeRepository { get; set; }

        public HabilidadeController()
        {
            _habilidadeRepository = new HabilidadeRepository();
        }

        /// <summary>
        /// Listar todas as habilidades
        /// </summary>
        /// <returns>Retorna um Status Code 200 junto com um lista de habilidades</returns>
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                return Ok(_habilidadeRepository.ListarTudo());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Buscar uma habilidade pelo seu Id
        /// </summary>
        /// <param name="id">id da habilidade</param>
        /// <returns>Retorna um Status Code 200 junto com a habilidade buscada</returns>
        [HttpGet("{id}")]
        [Authorize]

        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_habilidadeRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        
        /// <summary>
        /// Cadastra  uma nova habilidade
        /// </summary>
        /// <param name="habilidade">Credenciais dessa nova habilidade</param>
        /// <returns>Retorna um Status Code 201 - Created</returns>
        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Post(Habilidade habilidade)
        {
            try
            {
                _habilidadeRepository.Cadastrar(habilidade);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                  
            }
        }

        /// <summary>
        /// Deleta um habilidade
        /// </summary>
        /// <param name="id">Id da habilidade que será deletada</param>
        /// <returns>Retorna um Status Code 204 - NoContent</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Delete(int id)
        {
            try
            {
                _habilidadeRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza uma habilidade
        /// </summary>
        /// <param name="id">Id da habilidade que será atualizada</param>
        /// <param name="habilidade">Crendenciaias atualizadas da habilidade</param>
        /// <returns>Retorna Status Code 204 - NoContent</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Update(int id, Habilidade habilidade)
        {
            try
            {
                _habilidadeRepository.Atualizar(id ,habilidade);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
