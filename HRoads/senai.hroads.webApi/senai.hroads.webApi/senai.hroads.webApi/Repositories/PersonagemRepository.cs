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
            Personagem personagemBuscado = BuscarPorId(id);

            if (personagemBuscado != null)
            {
                personagemBuscado.Nome = personagemAtualizado.Nome;
                personagemBuscado.QntMana = personagemAtualizado.QntMana;
                personagemBuscado.QntVida = personagemAtualizado.QntVida;
                personagemBuscado.DataAtualizacao = personagemAtualizado.DataAtualizacao;
            }

            ctx.Personagens.Update(personagemBuscado);
            ctx.SaveChanges();
        }

        public Personagem BuscarPorId(int id)
        {
            return ctx.Personagens.Include(p => p.IdClassesNavigation).FirstOrDefault(p => p.IdPersonagens == id);
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
