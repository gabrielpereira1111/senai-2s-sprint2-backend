using senai_filmes_WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_WebApi.Interface
{
    interface IUsuarioRepository
    {
        UsuarioDomain Login(string email, string senha);
    }
}
