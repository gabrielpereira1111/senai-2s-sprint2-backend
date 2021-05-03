using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class PersonagemRepository : IPersonagemRepository
    {
        HRoadsContext ctx = new HRoadsContext();
        public void Atualizar(int id, Personagem personagemAtualizado)
        {
            throw new NotImplementedException();
        }

        public Personagem BuscarPorId(int id)
        {
            return ctx.Personagens.Include(p => p.IdClassesNavigation).FirstOrDefault(p => p.IdClasses == id);
        }

        public void Cadastrar(Personagem novoPersonagem)
        {
            ctx.Personagens.Add(novoPersonagem);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Personagem personagem = BuscarPorId(id);

            ctx.Personagens.Remove(personagem);
            ctx.SaveChanges();
        }

        public List<Personagem> ListarTudo()
        {
            return ctx.Personagens.OrderBy(p => p.IdClassesNavigation.Nome)
                .Include(p => p.IdClassesNavigation)
                .ToList();
        }
    }
}
