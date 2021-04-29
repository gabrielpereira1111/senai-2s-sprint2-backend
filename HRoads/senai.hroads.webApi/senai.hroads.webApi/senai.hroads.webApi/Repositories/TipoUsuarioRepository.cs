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
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        HRoadsContext ctx = new HRoadsContext(); 
        public void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            TipoUsuario tipoUsuarioBuscado = BuscarPorID(id);
            if (tipoUsuarioBuscado.Titulo != null)
            {
                tipoUsuarioBuscado.Titulo = tipoUsuarioAtualizado.Titulo;
            }
            ctx.TipoUsuarios.Update(tipoUsuarioBuscado);
            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorID(int id)
        {
            return ctx.TipoUsuarios.FirstOrDefault(tu => tu.IdTipoUsuario == id);
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(novoTipoUsuario);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            ctx.TipoUsuarios.Remove(BuscarPorID(id));
            ctx.SaveChanges();
        }

        public List<TipoUsuario> ListarTudo()
        {
            return ctx.TipoUsuarios.Include(tu => tu.Usuarios).ToList();
        }
    }
}
