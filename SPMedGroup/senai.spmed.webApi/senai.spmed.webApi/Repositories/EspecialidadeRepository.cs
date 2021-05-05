using Microsoft.EntityFrameworkCore;
using senai.spmed.webApi.Contexts;
using senai.spmed.webApi.Domains;
using senai.spmed.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmed.webApi.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        SPMedContext ctx = new SPMedContext();
        public void Atualizar(int id, Especialidade especialidadeAtualizada)
        {
            Especialidade especialidadeBuscada = BuscarPorId(id);

            if (especialidadeBuscada != null)
            {
                especialidadeBuscada.Nome = especialidadeAtualizada.Nome;
            }

            ctx.Especialidades.Update(especialidadeBuscada);
            ctx.SaveChanges();
        }

        public Especialidade BuscarPorId(int id)
        {
            return ctx.Especialidades.Include(e => e.Medicos).FirstOrDefault(m => m.Idespecialidades == id);
        }

        public void Cadastrar(Especialidade novaEspecialidade)
        {
            ctx.Especialidades.Add(novaEspecialidade);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Especialidades.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Especialidade> ListarTudo()
        {
            return ctx.Especialidades.Include(e => e.Medicos).ToList();
        }
    }
}
