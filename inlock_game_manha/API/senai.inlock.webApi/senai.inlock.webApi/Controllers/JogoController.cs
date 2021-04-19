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

        [HttpGet]

        public IActionResult Get()
        {
            List<JogoDomain> listaJogo = _jogoRepository.ListarTodos();
            return Ok(listaJogo);
        }

        [HttpPost]
        public IActionResult Cadastrar(JogoDomain novoJogo)
        {
            _jogoRepository.Cadastrar(novoJogo);
            return StatusCode(201);
        }


    }
}
