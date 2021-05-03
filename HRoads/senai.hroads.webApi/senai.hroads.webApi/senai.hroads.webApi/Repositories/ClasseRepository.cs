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
    public class ClasseRepository : IClasseRepository
    {
        HRoadsContext ctx = new HRoadsContext();
        public void Atualizar(int id, Classe classe)
        {
            Classe classeBuscada = BuscarPorId(id);

            if (classeBuscada != null)
            {
                classeBuscada.Nome = classe.Nome;
            }
            ctx.Classes.Update(classeBuscada);
            ctx.SaveChanges();
        }

        public Classe BuscarPorId(int id)
        {
            return ctx.Classes.Include(c => c.Personagens).FirstOrDefault(c => c.IdClasses == id);
        }

        public void Cadastrar(Classe novaClasse)
        {
            ctx.Classes.Add(novaClasse);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Classes.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Classe> ListarTudo()
        {
            return ctx.Classes.Include(c => c.Personagens).ToList();
        }
    }
}
