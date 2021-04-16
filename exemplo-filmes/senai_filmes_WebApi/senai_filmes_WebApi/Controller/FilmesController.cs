using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_WebApi.Domain;
using senai_filmes_WebApi.Interface;
using senai_filmes_WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_WebApi.Controller
{
    [Produces("application/JSON")]
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private IFilmeRepository _filmeRepository { get; set; }
        public FilmesController()
        {
            _filmeRepository = new FilmeRepository();
        }

        //-----------------------------------------------------------------------------------------------------------------------------
        [HttpGet]

        public IActionResult Get()
        {
            List<FilmeDomain> listaFilmes = _filmeRepository.ListarTudo();
            return Ok(listaFilmes);
        }

        //-----------------------------------------------------------------------------------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            FilmeDomain filmeBuscado = _filmeRepository.BuscarPorID(id);
            if (filmeBuscado == null)
            {
                return NotFound
                    (
                    new
                    {
                        mensagem = "Filme não encontrado",
                        erro = true
                    }
                    );
            }

            try
            {
                _filmeRepository.BuscarPorID(id);
                return Ok(filmeBuscado);

            }
            catch (Exception erro)
            {
                return BadRequest(erro);

            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------
        [HttpPut("{id}")]
        public IActionResult PutURL(int id, FilmeDomain filmeAtualizado)
        {
            FilmeDomain filmeBuscado = _filmeRepository.BuscarPorID(id);
            if (filmeBuscado == null)
            {
                return NotFound
                    (
                    new 
                        {
                            mensagem = "Gênero não encontrado",
                            erro = true
                        }
                    );
            }

            try
            {
                _filmeRepository.AtualizarIDURL(filmeAtualizado, id);
                return NoContent();

            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------

        [HttpPut]
        public IActionResult PutBody(FilmeDomain filmeAtualizado)
        {
            FilmeDomain filmeBuscado = _filmeRepository.BuscarPorID(filmeAtualizado.idGenero);
            if (filmeBuscado == null)
            {
                return NotFound
                    (
                    new
                    {
                        mensagem = "Gênero não encontrado",
                        erro = true
                    }
                    );
            }

            try
            {
                _filmeRepository.AtualizarIDCorpo(filmeAtualizado);
                return NoContent();

            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
        
        [HttpPost]

        public IActionResult Post(FilmeDomain novoFilme)
        {
            _filmeRepository.Cadastrar(novoFilme);
            return StatusCode(201);
        }

        //-----------------------------------------------------------------------------------------------------------------------------
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            _filmeRepository.Deletar(id);
            return StatusCode(204);
        }
    }
}
