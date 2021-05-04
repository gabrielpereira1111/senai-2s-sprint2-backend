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
    
    public class UsuarioRepository : IUsuarioRepository
    {
        SPMedContext ctx = new SPMedContext();

        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = BuscarPorId(id);
            if (usuarioBuscado != null)
            {
                usuarioBuscado.Email = usuarioAtualizado.Email;
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
            }
            ctx.Usuarios.Update(usuarioBuscado);
            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.Include(u => u.IdtiposUsuariosNavigation).Select(u => 
            new Usuario
            {
              Idusuarios = u.Idusuarios,
              IdtiposUsuarios = u.IdtiposUsuarios,
              Email = u.Email,
              IdtiposUsuariosNavigation = new TiposUsuario
              {
                  IdtiposUsuarios = u.IdtiposUsuariosNavigation.IdtiposUsuarios,
                  Tipo = u.IdtiposUsuariosNavigation.Tipo
              }
            }).FirstOrDefault(u => u.Idusuarios == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Usuarios.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Usuario> ListarTudo()
        {
            return ctx.Usuarios.Include(u => u.IdtiposUsuariosNavigation).Select(u =>
            new Usuario 
            {
                Idusuarios = u.Idusuarios,
                IdtiposUsuarios = u.IdtiposUsuarios,
                Email = u.Email,
                IdtiposUsuariosNavigation = new TiposUsuario
                {
                    IdtiposUsuarios = u.IdtiposUsuariosNavigation.IdtiposUsuarios,
                    Tipo = u.IdtiposUsuariosNavigation.Tipo
                }
            }). ToList();
        }

        public Usuario Login(string email, string senha)
        {
            Usuario usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
            return usuario;
        }
    }
}
