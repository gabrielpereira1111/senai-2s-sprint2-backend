using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IClasseRepository
    {
        /// <summary>
        /// Cadastra uma nova classe
        /// </summary>
        /// <param name="novaClasse">Credenciais da nova classe</param>
        void Cadastrar(Classe novaClasse);
        /// <summary>
        /// Lista todas as classes
        /// </summary>
        /// <returns>Retorna uma lista de classes</returns>
        List<Classe> ListarTudo();
        /// <summary>
        /// Busca uma classe a partir de seu Id
        /// </summary>
        /// <param name="id">Id da classe que será buscada</param>
        /// <returns></returns>
        Classe BuscarPorId(int id);
        /// <summary>
        /// Atualizar uma classe
        /// </summary>
        /// <param name="id">Id da classe que será atualizada</param>
        /// <param name="classe">Credenciais atualizadas da classe</param>
        void Atualizar(int id, Classe classe);
        /// <summary>
        /// Deletar uma classe
        /// </summary>
        /// <param name="id">Id da classe que será deletada</param>
        void Deletar(int id);
    }
}
