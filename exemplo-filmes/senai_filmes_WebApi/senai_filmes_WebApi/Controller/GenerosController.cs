using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_WebApi.Domain;
using senai_filmes_WebApi.Interface;
using senai_filmes_WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controller responsável pelos endpoints(URLs) referentes aos gêneros
/// </summary>
namespace senai_filmes_WebApi.Controller
{
    //Define que o tipo de resposta da API é tipo JSON
    [Produces("application/json")]
    //Define que a rota da requisição será no formato dominio/api/nomeController
    //ex: http://localhost:5000/api/Generos
    [Route("api/[controller]")]
    //Define que é um controlador de API
    [ApiController]
    public class GenerosController : ControllerBase
    {
        /// <summary>
        /// Objeto chamado _generoRepository que irá receber todos os métodos definidos na interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _generoRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public GenerosController()
        {
            _generoRepository = new GeneroRepository();

        }
        
        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns> Uma lista de gêneros e um status code</returns>
        /// Domínio/API/Gêneros
        [Authorize] //Define que usuário precisa estar logado
        [HttpGet]
        public IActionResult Get()
        {
            //Cria lista nomeada listaGeneros para receber os dados
            List<GeneroDomain> listaGeneros = _generoRepository.ListarTudo();
            //Retorna o status code 200 (Ok) com a lista de gêneros o formato JSON
            return Ok(listaGeneros);
        }

        /// <summary>
        /// Lista o genero a partir do id
        /// </summary>
        /// <param name="id">id do gênero</param>
        /// <returns>Gênero correspondente ao id</returns>
        [Authorize] //O Usuário precisa estar logado
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            if (generoBuscado == null)
            {
                return NotFound
                    (
                    new
                        { 
                            mensagem = "Gênero não encontrado!",
                            erro = true
                        }
                    );;
            }

            return Ok(generoBuscado);
        }
        
        /// <summary>
        /// Atualiza o Gênero
        /// </summary>
        /// <param name="generoAtualizado">Gênero que será analisado</param>
        /// <returns>Gênero atualizado</returns>
        [Authorize(Roles ="administrador")] //Somente o administrado pode atualizar um usuário
        [HttpPut]

        public IActionResult PutBody(GeneroDomain generoAtualizado)
        {
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(generoAtualizado.idGenero);
            if (generoAtualizado != null)
            {
                try
                {
                    _generoRepository.AtualizarCorpo(generoAtualizado);
                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            return NotFound
                (
                new 
                {
                    mensagem = "Gênero não encontrado",
                    erro = true
                }
                );

        }

        [Authorize(Roles = "administrador")]
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, GeneroDomain generoAtualizado)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
            // e um bool para apresentar que houve erro
            if (generoBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Gênero não encontrado!",
                        erro = true
                    }
                    );
            }

            // Tenta atualizar o registro
            try
            {
                // Faz a chamada para o método .AtualizarIdUrl()
                _generoRepository.AtualizarURL(id, generoAtualizado);

                // Retorna um status code 204 - No Content
                return NoContent();
            }
            // Caso ocorra algum erro
            catch (Exception erro)
            {
                // Retorna um status 400 - BadRequest e o código do erro
                return BadRequest(erro);
            }
        }



        /// <summary>
        /// Cadastra um novo genero
        /// </summary>
        /// <param name="novoGenero">Objeto novoGenero recebido na requisição</param>
        /// <returns> Um Status Code 201 - Created</returns>
        [Authorize(Roles = "administrador")] //Somente o administrador pode cadastrar um novo usuário
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
           //Faz a chamada para o método .Cadastrar()
            _generoRepository.Cadastrar(novoGenero);
            //Retorna Status Code Created
            return StatusCode(201);

        }

        [Authorize(Roles ="administrador")]  //Somente o administrador pode deletar um usuário
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            _generoRepository.Deletar(id);
            return StatusCode(204);
        }
    }
}
