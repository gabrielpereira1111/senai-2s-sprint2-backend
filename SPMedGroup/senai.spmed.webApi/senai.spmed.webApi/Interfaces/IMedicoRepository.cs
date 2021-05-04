using senai.spmed.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmed.webApi.Interfaces
{
    interface IMedicoRepository
    {
        /// <summary>
        /// Cadastra um novo médico
        /// </summary>
        /// <param name="novoMedico">Credenciais do médico cadastrado</param>
        void Cadastrar(Medico novoMedico);
        /// <summary>
        /// Lista todos os médicos
        /// </summary>
        /// <returns>Retorna uma lista de médicos</returns>
        List<Medico> ListarTudo();
        /// <summary>
        /// Busca por um médico através de seu Id
        /// </summary>
        /// <param name="id">Id do médico buscado</param>
        /// <returns>Retorna um médico</returns>
        Medico BuscarPorId(int id);
        /// <summary>
        /// Atualiza as credenciais de um médico
        /// </summary>
        /// <param name="id">Id do médico que terá suas credenciais atualizadas</param>
        /// <param name="medicoAtualizado">Credenciais atualizadas do médico</param>
        void Atualizar(int id, Medico medicoAtualizado);
        /// <summary>
        /// Deleta um médico
        /// </summary>
        /// <param name="id">Id do médico que terá suas credenciais deletadas</param>
        void Deletar(int id);
    }
}
