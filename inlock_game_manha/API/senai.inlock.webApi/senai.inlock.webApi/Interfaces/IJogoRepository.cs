using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IJogoRepository
    {
        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns> Lista de jogos </returns>
        List<JogoDomain> ListarTodos();

        /// <summary>
        /// Cadastrar um jogo
        /// </summary>
        /// <param name="novoJogo"> Jogo cadastrado</param>
        void Cadastrar(JogoDomain novoJogo);
    }
}
