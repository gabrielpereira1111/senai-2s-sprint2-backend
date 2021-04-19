using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Listar todos os usuários
        /// </summary>
        /// <returns>Lista de todos os usuários</returns>
        List<UsuarioDomain> ListarTodos();
        /// <summary>
        /// Cadastrar um novo usuário
        /// </summary>
        /// <param name="novoUsuario"> Novo usuário cadastrado</param>
        void Cadastrar(UsuarioDomain novoUsuario);
        UsuarioDomain Login(string email, string senha);
    }
}
