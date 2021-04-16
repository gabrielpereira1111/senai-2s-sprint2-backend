using senai_filmes_WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_WebApi.Interface
{
    /// <summary>
    /// Interface responsável pelo Repositório de Gêneros
    /// </summary>
    /// A interface diz o que vai ser feito
    public interface IGeneroRepository
    {
        /// <summary>
        /// Retorna todos os gêneros
        /// </summary>
        /// <returns>lista de gêneros</returns>
        List<GeneroDomain> ListarTudo();
        /// <summary>
        /// Busca um Gênero pelo ID
        /// </summary>
        /// <param name="id">ID do gênero que será buscado</param>
        /// <returns>Um objeto do tipo GeneroDomain que foi buscado</returns>
        GeneroDomain BuscarPorId(int id);
        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto novoGenero que será cadastrado</param>
        void Cadastrar(GeneroDomain novoGenero);
        /// <summary>
        /// Atualiza um gênero existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="genero"> Objeto genero que será atualizado </param>
        void AtualizarCorpo(GeneroDomain genero);
        /// <summary>
        /// Atualiza um gênero existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="id"></param>
        /// <param name="genero"></param>
        void AtualizarURL(int id, GeneroDomain genero);

        void Deletar(int id);

    }
}
