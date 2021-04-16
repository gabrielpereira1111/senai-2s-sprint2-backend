using senai_filmes_WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_WebApi.Interface
{
    interface IFilmeRepository
    {
        List<FilmeDomain> ListarTudo();
        FilmeDomain BuscarPorID(int id);
        void Cadastrar(FilmeDomain novoFilme);
        void AtualizarIDCorpo(FilmeDomain filme);
        void AtualizarIDURL(FilmeDomain filme, int id);
        void Deletar(int id);

    }
}
