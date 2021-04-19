using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface ItipoUsuarioRepository
    {
        /// <summary>
        /// Listar todos os tipos de usuário
        /// </summary>
        /// <returns> Lista de tipos de usuário</returns>
        List<tipoUsuarioDomain> ListarTodos();
        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Novo tipo de usuário cadastrado</param>
        void Cadastrar(tipoUsuarioDomain novoTipoUsuario);
    }
}
