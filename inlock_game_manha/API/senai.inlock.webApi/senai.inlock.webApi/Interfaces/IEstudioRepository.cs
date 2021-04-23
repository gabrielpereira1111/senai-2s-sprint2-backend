using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IEstudioRepository
    {
        /// <summary>
        /// Listar todos os estúdios
        /// </summary>
        /// <returns>Lista de estúdios</returns>
        List<EstudioDomain> ListarTodos();
        /// <summary>
        /// Cadastrar novo estúdio
        /// </summary>
        /// <param name="novoEstudio"> Estúdio cadastrado </param>
        void Cadastrar(EstudioDomain novoEstudio);
        /// <summary>
        /// Lista os estudios e seus respectivos jogos
        /// </summary>
        /// <returns> Uma lista de estudios com os seus jogos</returns>
       
    }
}
