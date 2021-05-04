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
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        SPMedContext ctx = new SPMedContext();
        public void Atualizar(int id, TiposUsuario tipoUsuarioAtualizado)
        {
            TiposUsuario tipoUsuarioBuscado = BuscarPorId(id);
            if (tipoUsuarioBuscado != null)
            {
                tipoUsuarioBuscado.Tipo = tipoUsuarioAtualizado.Tipo;
            }

            ctx.TiposUsuarios.Update(tipoUsuarioBuscado);
            ctx.SaveChanges();
        }

        public TiposUsuario BuscarPorId(int id)
        {
            return ctx.TiposUsuarios.FirstOrDefault(tu => tu.IdtiposUsuarios == id);
        }

        public void Cadastrar(TiposUsuario novoTipoUsuario)
        {
            ctx.TiposUsuarios.Add(novoTipoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.TiposUsuarios.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<TiposUsuario> ListarTudo()
        {
            return ctx.TiposUsuarios.ToList();
        }
    }
}
