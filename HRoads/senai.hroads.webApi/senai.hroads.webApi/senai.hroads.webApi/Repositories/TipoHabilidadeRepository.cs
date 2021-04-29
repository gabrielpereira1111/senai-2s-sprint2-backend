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
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        HRoadsContext ctx = new HRoadsContext();
        public void Atualizar(int id, TiposHabilidade tipoHabilidadeAtualizado)
        {
            TiposHabilidade tipoHabBuscado = BuscarPorId(id);
            if (tipoHabBuscado.Nome != null)
            {
                tipoHabBuscado.Nome = tipoHabilidadeAtualizado.Nome;
            }
            ctx.TiposHabilidades.Update(tipoHabBuscado);
            ctx.SaveChanges();
        }

        public TiposHabilidade BuscarPorId(int id)
        {
            TiposHabilidade tiposHabBuscado = ctx.TiposHabilidades.Include(th => th.Habilidades).FirstOrDefault(th => th.IdTipo == id);
            return tiposHabBuscado;
        }

        public void Cadastrar(TiposHabilidade novoTipoHabilidade)
        {
            ctx.TiposHabilidades.Add(novoTipoHabilidade);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {

            ctx.TiposHabilidades.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<TiposHabilidade> ListarTudo()
        {
            return ctx.TiposHabilidades.Include(th => th.Habilidades).ToList();
        }
    }
}
