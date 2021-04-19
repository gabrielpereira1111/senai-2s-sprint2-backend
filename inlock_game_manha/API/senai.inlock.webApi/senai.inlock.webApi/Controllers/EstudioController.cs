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
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }
        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<EstudioDomain> listaEstudio = _estudioRepository.ListarTodos();
            return Ok(listaEstudio);
        }

        [HttpPost]
        public IActionResult Cadastrar(EstudioDomain novoEstudio)
        {
            _estudioRepository.Cadastrar(novoEstudio);
            return StatusCode(201);
        }
    }
}
