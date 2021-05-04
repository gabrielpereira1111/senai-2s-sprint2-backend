using senai.spmed.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmed.webApi.Interfaces
{
    interface IPacienteRepository
    {
        /// <summary>
        /// Cadastra um novo paciente
        /// </summary>
        /// <param name="novoPaciente">Credenciais do novo paciente</param>
        void Cadastrar(Paciente novoPaciente);
        /// <summary>
        /// Lista todos os pacientes
        /// </summary>
        /// <returns>Retorna uma lista de pacientes</returns>
        List<Paciente> ListarTudo();
        /// <summary>
        /// Busca um paciente através de seu Id
        /// </summary>
        /// <param name="id">Id do paciente buscado</param>
        /// <returns>Retorna um paciente</returns>
        Paciente BuscarPorId(int id);
        /// <summary>
        /// Atualiza um paciente
        /// </summary>
        /// <param name="id">Id do paciente que será atualizado</param>
        /// <param name="pacienteAtualizado">Credenciais atualizadas do paciente</param>
        void Atualizar(int id, Paciente pacienteAtualizado);
        /// <summary>
        /// Deleta um paciente
        /// </summary>
        /// <param name="id">Id do paciente que será deletado</param>
        void Deletar(int id);
    }
}
