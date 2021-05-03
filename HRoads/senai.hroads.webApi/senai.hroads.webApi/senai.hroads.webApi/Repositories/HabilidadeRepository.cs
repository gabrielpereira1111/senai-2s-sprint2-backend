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
    public class HabilidadeRepository : IHabilidadeRepository
    {
        HRoadsContext ctx = new HRoadsContext();
        public void Atualizar(int id, Habilidade habilidadeAtualizada)
        {
            Habilidade habilidadeBuscada = BuscarPorId(id);
            if (habilidadeBuscada != null)
            {
                habilidadeBuscada.Nome = habilidadeAtualizada.Nome;
                habilidadeBuscada.IdTipo = habilidadeAtualizada.IdTipo;
            }
            ctx.Habilidades.Update(habilidadeAtualizada);
            ctx.SaveChanges();
        }

        public Habilidade BuscarPorId(int id)
        {
            return ctx.Habilidades.Include(h => h.IdTipoNavigation).FirstOrDefault(h => h.IdHabilidades == id);
        }

        public void Cadastrar(Habilidade novaHabilidade)
        {
            ctx.Habilidades.Add(novaHabilidade);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Habilidades.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Habilidade> ListarTudo()
        {
            return ctx.Habilidades.Include(h => h.IdTipoNavigation).Include(h => h.ClassesHabilidades).ToList();
        }
    }
}
