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
    public class UsuarioRepository : IUsuarioRepository
    {
        HRoadsContext ctx = new HRoadsContext();
        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = BuscarPorID(id);
            if (usuarioBuscado.Email != null)
            {
                usuarioBuscado.Email = usuarioAtualizado.Email;
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
                usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;
            }
            ctx.Usuarios.Update(usuarioBuscado);
            ctx.SaveChanges();
        }

        public Usuario BuscarPorID(int id)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuarios == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Usuarios.Remove(BuscarPorID(id));
            ctx.SaveChanges();
        }

        public List<Usuario> ListarTudo()
        {
            return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation).ToList();
        }
            
        public Usuario Login(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
