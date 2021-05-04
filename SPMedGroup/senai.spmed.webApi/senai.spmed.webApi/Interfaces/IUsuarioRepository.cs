using senai.spmed.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmed.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Credenciais do novo usuário</param>
        void Cadastrar(Usuario novoUsuario);
        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Retorna uma lista de usuários</returns>
        List<Usuario> ListarTudo();
        /// <summary>
        /// Busca um usuário através de seu Id
        /// </summary>
        /// <param name="id">Id do usuário buscado</param>
        /// <returns>Retorna o usuário buscado</returns>
        Usuario BuscarPorId(int id);
        /// <summary>
        /// Atualiza um usuário
        /// </summary>
        /// <param name="id">Id do usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">Credenciais atualizadas do usuário que será atualizado</param>
        void Atualizar(int id, Usuario usuarioAtualizado);
        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="id">Id do usuário que será deletado</param>
        void Deletar(int id);
        /// <summary>
        /// Faz o login
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Retorna um usuário</returns>
        Usuario Login(string email, string senha);
    }
}
