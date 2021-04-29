using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Cadastrar um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Credenciais do novo usuário</param>
        void Cadastrar(Usuario novoUsuario);
        /// <summary>
        /// Listar todos os usuários
        /// </summary>
        /// <returns>Lista de usuários</returns>
        List<Usuario> ListarTudo();
        /// <summary>
        /// Buscar por um usuário a partir do Id
        /// </summary>
        /// <param name="id">Id do usuário buscado</param>
        /// <returns>Um usuário</returns>
        Usuario BuscarPorID(int id);
        /// <summary>
        /// Atualizar um usuário
        /// </summary>
        /// <param name="id">Id do usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">Credenciais que serão atualizadas do usuário</param>
        void Atualizar(int id, Usuario usuarioAtualizado);
        /// <summary>
        /// Deletar um usuário
        /// </summary>
        /// <param name="id">id do usuário que será deletado</param>
        void Deletar(int id);
        Usuario Login(string email, string senha);
    }
}
