using senai.spmed.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmed.webApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Credenciais do novo tipo de usuário</param>
        void Cadastrar(TiposUsuario novoTipoUsuario);
        /// <summary>
        /// Lista todos os tipos de usuário
        /// </summary>
        /// <returns>Retorna uma lista de tipos de usuários</returns>
        List<TiposUsuario> ListarTudo();
        /// <summary>
        /// Busca um usuário através de seu Id
        /// </summary>
        /// <param name="id">Id do usuário que será buscado</param>
        /// <returns>Retorna um tipo de usuário</returns>
        TiposUsuario BuscarPorId(int id);
        /// <summary>
        /// Atualiza um tipo de usuário
        /// </summary>
        /// <param name="id">Id do usuário que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Credenciais atualizadas do tipo de usuário</param>
        void Atualizar(int id, TiposUsuario tipoUsuarioAtualizado);
        /// <summary>
        /// Deleta um tipo de usuário
        /// </summary>
        /// <param name="id">Id do usuário que será deletado</param>
        void Deletar(int id);
    }
}
