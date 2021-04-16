using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_WebApi.Domain
{
    public class GeneroDomain
    {
        /// <summary>
        /// Classe que representa a entidade(tabela) Generos
        /// </summary>
        public int idGenero { get; set; }
        public string Nome { get; set; }
    }
}
