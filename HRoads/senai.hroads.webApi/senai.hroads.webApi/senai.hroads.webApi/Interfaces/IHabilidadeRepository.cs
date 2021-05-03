using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IHabilidadeRepository
    {
        /// <summary>
        /// Cadastrar uma nova habilidade
        /// </summary>
        /// <param name="novaHabilidade">Credenciais da novaHabilidade</param>
        void Cadastrar(Habilidade novaHabilidade);
        /// <summary>
        /// Listar todas as habilidades
        /// </summary>
        /// <returns>Lista de todas as habilidades</returns>
        List<Habilidade> ListarTudo();
        /// <summary>
        /// Habilidade buscada a partir de seu id
        /// </summary>
        /// <param name="id">id da habilidade buscada</param>
        /// <returns>Uma habilidade</returns>
        Habilidade BuscarPorId(int id);
        /// <summary>
        /// Atualizar uma habilidade
        /// </summary>
        /// <param name="id">id da habiliadade que será atualizada</param>
        /// <param name="habilidadeAtualizada">credenciais atualizadas da habilidade</param>
        void Atualizar(int id, Habilidade habilidadeAtualizada);
        /// <summary>
        /// Deletar uma habilidade
        /// </summary>
        /// <param name="id">Id da habilidade que será deletada</param>
        void Deletar(int id);

    }
}
