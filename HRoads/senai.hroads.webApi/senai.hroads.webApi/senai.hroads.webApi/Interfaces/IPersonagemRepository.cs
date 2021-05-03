using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IPersonagemRepository
    {
        /// <summary>
        /// Cadastrar um novo personagem
        /// </summary>
        /// <param name="novoPersonagem">Credenciais desse novo personagem</param>
        void Cadastrar(Personagem novoPersonagem);
        /// <summary>
        /// Listar todos os personagens
        /// </summary>
        /// <returns></returns>
        List<Personagem> ListarTudo();
        /// <summary>
        /// Buscar um personagem a partir do seu id
        /// </summary>
        /// <param name="id">Id do personagem buscado</param>
        /// <returns>Um personagem</returns>
        Personagem BuscarPorId(int id);
        /// <summary>
        /// Atualizar um personagem
        /// </summary>
        /// <param name="id">Id do personagem que será atualizado</param>
        /// <param name="personagemAtualizado">Credenciais atualizadas desse personagem</param>
        void Atualizar(int id, Personagem personagemAtualizado);
        /// <summary>
        /// Deletar um personagem
        /// </summary>
        /// <param name="id">Id do personagem que será deletado</param>
        void Deletar(int id);
    }
}
