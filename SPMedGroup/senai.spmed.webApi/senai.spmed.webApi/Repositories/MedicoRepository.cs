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
    public class MedicoRepository : IMedicoRepository
    {
        SPMedContext ctx = new SPMedContext(); 
        public void Atualizar(int id, Medico medicoAtualizado)
        {
            Medico medico = ctx.Medicos.Find(id);

            if (medico.Idespecialidades != null)
            {
                medico.Idespecialidades = medicoAtualizado.Idespecialidades;
            }
            ctx.Medicos.Update(medico);
            ctx.SaveChanges();
        }

        public Medico BuscarPorId(int id)
        {
            return ctx.Medicos.Include(m => m.IdespecialidadesNavigation).Include(m => m.IdusuariosNavigation).Include(m => m.IdclinicasNavigation)
                .Include(m => m.Consulta)
                .Select(m => new Medico
                {
                    Idmedicos = m.Idmedicos,
                    Idespecialidades = m.Idespecialidades,
                    Idusuarios = m.Idusuarios,
                    Idclinicas = m.Idclinicas,
                    Nome = m.Nome,
                    Crm = m.Crm,
                    IdclinicasNavigation = new Clinica
                    {
                        Idclinicas = m.IdclinicasNavigation.Idclinicas,
                        NomeFantasia = m.IdclinicasNavigation.NomeFantasia,
                        RazaoSocial = m.IdclinicasNavigation.RazaoSocial,
                        Endereco = m.IdclinicasNavigation.Endereco
                    },
                    IdespecialidadesNavigation = new Especialidade
                    {
                        Idespecialidades = m.IdespecialidadesNavigation.Idespecialidades,
                        Nome = m.IdespecialidadesNavigation.Nome
                    },
                    IdusuariosNavigation = new Usuario
                    {
                        Idusuarios = m.IdusuariosNavigation.Idusuarios,
                        Email = m.IdusuariosNavigation.Email
                    }

                }).FirstOrDefault(m => m.Idmedicos == id);
        }

        public void Cadastrar(Medico novoMedico)
        {
            ctx.Medicos.Add(novoMedico);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Medicos.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Medico> ListarTudo()
        {
            return ctx.Medicos.Include(m => m.IdespecialidadesNavigation).Include(m => m.IdusuariosNavigation).Include(m => m.IdclinicasNavigation)
                .Include(m => m.Consulta)
                .Select(m => new Medico
                {
                    Idmedicos = m.Idmedicos,
                    Idespecialidades = m.Idespecialidades,
                    Idusuarios = m.Idusuarios,
                    Idclinicas = m.Idclinicas,
                    Nome = m.Nome,
                    Crm = m.Crm,
                    IdclinicasNavigation = new Clinica
                    {
                        Idclinicas = m.IdclinicasNavigation.Idclinicas,
                        NomeFantasia = m.IdclinicasNavigation.NomeFantasia,
                        RazaoSocial = m.IdclinicasNavigation.RazaoSocial,
                        Endereco = m.IdclinicasNavigation.Endereco
                    },
                    IdespecialidadesNavigation = new Especialidade
                    {
                        Idespecialidades = m.IdespecialidadesNavigation.Idespecialidades,
                        Nome = m.IdespecialidadesNavigation.Nome
                    },
                    IdusuariosNavigation = new Usuario
                    {
                        Idusuarios = m.IdusuariosNavigation.Idusuarios,
                        Email = m.IdusuariosNavigation.Email
                    }

                }).ToList();
        }
    }
}
