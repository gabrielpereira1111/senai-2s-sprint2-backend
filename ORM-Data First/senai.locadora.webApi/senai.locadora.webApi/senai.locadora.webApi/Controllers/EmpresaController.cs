using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.locadora.webApi.Domains;
using senai.locadora.webApi.Interfaces;
using senai.locadora.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.locadora.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private IEmpresaRepository _empresaRepository { get; set; }

        public EmpresaController()
        {
            _empresaRepository = new EmpresaRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_empresaRepository.ListarTudo());
        }


        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            return Ok(_empresaRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Empresa novaEmpresa)
        {
            _empresaRepository.Cadastrar(novaEmpresa);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _empresaRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Empresa empresaAtualizada)
        {
            _empresaRepository.Atualizar(id, empresaAtualizada);
            return NoContent();
        }

        [HttpGet("veiculos")]

        public IActionResult GetVeiculos()
        {
            return Ok(_empresaRepository.ListaVeiculos());
        }

        
    }
}
