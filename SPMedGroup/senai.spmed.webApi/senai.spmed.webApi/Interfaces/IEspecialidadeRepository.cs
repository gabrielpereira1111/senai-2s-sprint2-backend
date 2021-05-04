using senai.spmed.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmed.webApi.Interfaces
{
    interface IEspecialidadeRepository
    {
        /// <summary>
        /// Cadastra uma nova especialidade
        /// </summary>
        /// <param name="novaEspecialidade">Credenciais da nova especialidade</param>
        void Cadastrar(Especialidade novaEspecialidade);
        /// <summary>
        /// Lista todas as especialidades
        /// </summary>
        /// <returns>Retorna uma lista de especialidades</returns>
        List<Especialidade> ListarTudo();
        /// <summary>
        /// Buscar por um especialidade
        /// </summary>
        /// <param name="id">Id da especialidade que será buscada</param>
        /// <returns></returns>
        Especialidade BuscarPorId(int id);
        /// <summary>
        /// Atualiza uma especialidade
        /// </summary>
        /// <param name="id">Id da especialidade</param>
        /// <param name="especialidadeAtualizada">Credenciais atualizadas da especialidade</param>
        void Atualizar(int id, Especialidade especialidadeAtualizada);
        /// <summary>
        /// Deleta uma especialidade
        /// </summary>
        /// <param name="id">Id da especialidade que será deletada</param>
        void Deletar(int id);
    }
}
