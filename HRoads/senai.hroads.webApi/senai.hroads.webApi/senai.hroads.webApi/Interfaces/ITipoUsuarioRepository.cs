using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Credenciais atualizadas do novo Tipo de Usuário</param>
        void Cadastrar(TipoUsuario novoTipoUsuario);
        /// <summary>
        /// Listar todos os tipos de usuário
        /// </summary>
        /// <returns>Lista de tipos de usupario</returns>
        List<TipoUsuario> ListarTudo();
        /// <summary>
        /// Buscar por um tipo de usuário a partir de seu ID
        /// </summary>
        /// <param name="id">Id do tipo de usuário</param>
        /// <returns>Tipo de usuário buscado pelo id</returns>
        TipoUsuario BuscarPorID(int id);
        /// <summary>
        /// Atualizar um tipo de usuário
        /// </summary>
        /// <param name="id">Id do tipo usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">Credenciais do tipo de usuário que será cadastrado</param>
        void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado);
        /// <summary>
        /// Deletar um tipo de usuário
        /// </summary>
        /// <param name="id">id do tipo de usuário que será deletado</param>
        void Delete(int id);

    }
}
