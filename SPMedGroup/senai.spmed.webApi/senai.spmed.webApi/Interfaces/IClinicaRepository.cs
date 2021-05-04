using senai.spmed.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmed.webApi.Interfaces
{
    interface IClinicaRepository
    {
        /// <summary>
        /// Cadastra uma nova clínica
        /// </summary>
        /// <param name="novaClinica">Credenciais da nova clínica</param>
        void Cadastrar(Clinica novaClinica);
        /// <summary>
        /// Lista de todas as clínicas
        /// </summary>
        /// <returns>Retorna uma lista de clínicas</returns>
        List<Clinica> ListarTudo();
        /// <summary>
        /// Busca por uma clínica através de seu Id
        /// </summary>
        /// <param name="id">Id da clínica buscada</param>
        /// <returns>Retorna uma clínica</returns>
        Clinica BuscarPorId(int id);
        /// <summary>
        /// Atualiza uma clínica
        /// </summary>
        /// <param name="id">Id da clínica</param>
        /// <param name="clinicaAtualizada">Credenciais atualizadas da clínica</param>
        void Atualizar(int id, Clinica clinicaAtualizada);
        /// <summary>
        /// Deleta uma clínica
        /// </summary>
        /// <param name="id">Id da clínica</param>
        void Deletar(int id);
    }
}
