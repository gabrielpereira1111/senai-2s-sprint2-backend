using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        /// <summary>
        /// Cadastrar um novo tipo de habilidade
        /// </summary>
        /// <param name="novoTipoHabilidade">Credenciais do novo tipo de habilidade</param>
        void Cadastrar(TiposHabilidade novoTipoHabilidade);
        /// <summary>
        /// Listar todos os tipos de habilidade
        /// </summary>
        /// <returns>Lista de habilidades</returns>
        List<TiposHabilidade> ListarTudo();
        /// <summary>
        /// Busca por um tipo de habilidade a partir do id
        /// </summary>
        /// <param name="id">Id do tipo de habilidade buscada</param>
        /// <returns>Tipo de Habilidade</returns>
        TiposHabilidade BuscarPorId(int id);
        /// <summary>
        /// Atualizar um tipo de habilidade
        /// </summary>
        /// <param name="id">Id do tipo de habilidade que será atualizado</param>
        /// <param name="tipoHabilidadeAtualizado">Credenciais atualizadas do tipoHabilidade</param>
        void Atualizar(int id, TiposHabilidade tipoHabilidadeAtualizado);
        /// <summary>
        /// Deletar um tipo de habilidade
        /// </summary>
        /// <param name="id">Id do tipo de habilidade que será deletado</param>
        void Deletar(int id);
    }
}
