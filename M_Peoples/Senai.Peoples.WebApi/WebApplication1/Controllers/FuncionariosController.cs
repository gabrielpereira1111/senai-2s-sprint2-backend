using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Domains;
using WebApplication1.Interfaces;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Produces ("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private IFuncionariosRepository _funcionariosRepository { get; set; }

        public FuncionariosController()
        {
            _funcionariosRepository = new FuncionariosRepository();
        }


        [HttpGet]

        public IActionResult Get()
        {
            List<FuncionariosDomain> listaFuncionarios =_funcionariosRepository.ListarTudo();
            return Ok(listaFuncionarios);
        }



        [HttpGet("{id}")]


        public IActionResult GetByID(int id)
        {
            FuncionariosDomain funcionariosBuscado = _funcionariosRepository.BuscarPorID(id);

            if (funcionariosBuscado == null)
            {
                return NotFound
                    (
                    new
                        {
                            mensagem = "Funcionario não encontrado",
                            erro = true
                        }
                    );
            }

            try
            {
                _funcionariosRepository.BuscarPorID(id);
                return Ok(funcionariosBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
        
        [HttpPost]

        public IActionResult Cadastrar(FuncionariosDomain novoFuncionario)
        {
            _funcionariosRepository.Cadastrar(novoFuncionario);
            return StatusCode(201);
        }



        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            _funcionariosRepository.Deletar(id);
            return StatusCode(204);

        }



        [HttpPut]


        public IActionResult Put(FuncionariosDomain funcionarioAtualizado)
        {
            FuncionariosDomain funcionarioBuscado = _funcionariosRepository.BuscarPorID(funcionarioAtualizado.idFuncionarios);
            if (funcionarioAtualizado == null)
            {
                return NotFound
                    (
                    new 
                        { 
                            mensagem = "Funcionario não encontrado",
                            erro = true                   
                        }
                    );

            }

            try
            {
                _funcionariosRepository.Atualizar(funcionarioAtualizado);
                return NoContent();

            }
            catch (Exception erro)
            {

                return BadRequest(erro);

            }
        }


        [HttpGet("buscar/{nome}")]

        public IActionResult GetByName(string nome)
        {
            List<FuncionariosDomain> funcionarioBuscado = _funcionariosRepository.BuscarPorNome(nome);
            return Ok(funcionarioBuscado);
        }



        [HttpGet("nomescompletos")]

        public IActionResult GetByFullName()
        {
            List<FuncionariosDomain> listaFuncionarios =_funcionariosRepository.listarNomeCompleto();
            return Ok(listaFuncionarios);
            
        }


        [HttpGet("ordenacao/{ordem}")]

        public IActionResult GetByOrder(string ordem)
        {
            List<FuncionariosDomain> listaFuncionarios = _funcionariosRepository.listarOrdenacao(ordem);
            if (ordem != "ASC" && ordem != "DESC")
            {
                return BadRequest("Essa ordem é inválida");

            }

            return Ok(listaFuncionarios);
        }
    }
}
