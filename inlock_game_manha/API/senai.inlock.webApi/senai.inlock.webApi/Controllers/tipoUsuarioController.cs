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
    public class tipoUsuarioController : ControllerBase
    {
        private ItipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public tipoUsuarioController()
        {
            _tipoUsuarioRepository = new tipoUsuarioRepository(); 
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<tipoUsuarioDomain> listaTipoUsuario = _tipoUsuarioRepository.ListarTodos();
            return Ok(listaTipoUsuario);
        }

        [HttpPost]

        public IActionResult Cadastrar(tipoUsuarioDomain novoTipoUsuario)
        {
            _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);
            return StatusCode(201);
        }

    }
}
