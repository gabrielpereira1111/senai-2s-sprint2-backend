using senai.spmed.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmed.webApi.Interfaces
{
    interface IConsultaRepository
    {
        /// <summary>
        /// Cadastra uma nova consulta
        /// </summary>
        /// <param name="novaConsulta">Credenciais da nova consulta</param>
        void Cadastrar(Consulta novaConsulta);
        /// <summary>
        /// Lista todas as consultas
        /// </summary>
        /// <returns>Retorna uma lista de consulta</returns>
        List<Consulta> ListarTudo();
        /// <summary>
        /// Busca por uma consulta através do Id
        /// </summary>
        /// <param name="id">Id da consulta</param>
        /// <returns>Retorna uma consulta</returns>
        Consulta BuscarPorId(int id);
        /// <summary>
        /// Atualiza uma consulta
        /// </summary>
        /// <param name="id">Id da consulta</param>
        /// <param name="consultaAtualizada">Credenciais atualizadas da consulta</param>
        void Atualizar(int id, Consulta consultaAtualizada);
        /// <summary>
        /// Deleta uma consulta
        /// </summary>
        /// <param name="id">Id da consulta que será deletada</param>
        void Deletar(int id);
        /// <summary>
        /// Atualiza a situação da consulta
        /// </summary>
        /// <param name="id">Id da consulta</param>
        /// <param name="situacao">Situação da consulta</param>
        void atualizarSituacao(int id, string situacao);
        /// <summary>
        /// Lista as consultas associadas a um determinado medico
        /// </summary>
        /// <param name="id">Id do médico</param>
        /// <returns>Retorna uma lista de consultas associadas a um médico</returns>
        List<Consulta> listarMedicos(int id);
        /// <summary>
        /// Lista consultas de um determinado paciente
        /// </summary>
        /// <param name="id">Id do paciente</param>
        /// <returns>Retorna uma lista de consultas de um determinado paciente</returns>
        List<Consulta> listarPacientes(int id);
    }
}
