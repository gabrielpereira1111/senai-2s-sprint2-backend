using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {

        private IJogoRepository _jogoRepository { get; set; }
        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns> Lista de jogos</returns>
        [Authorize]
        [HttpGet]

        public IActionResult Get()
        {
            List<JogoDomain> listaJogo = _jogoRepository.ListarTodos();
            return Ok(listaJogo);
        }

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">Jogo que será cadastrado</param>
        /// <returns> Status Code Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(JogoDomain novoJogo)
        {
            _jogoRepository.Cadastrar(novoJogo);
            return StatusCode(201);
        }


    }
}
