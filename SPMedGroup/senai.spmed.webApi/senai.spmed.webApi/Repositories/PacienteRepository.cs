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
    public class PacienteRepository : IPacienteRepository
    {
        SPMedContext ctx = new SPMedContext();
        public void Atualizar(int id, Paciente pacienteAtualizado)
        {
            Paciente pacienteBuscado = ctx.Pacientes.Find(id);

            ///     pacienteBuscado precisa ser achado então ---> != null
            ///     Atualizar uma coluna ou as duas
            ///     

            if (pacienteBuscado != null)
            {
                if (pacienteAtualizado.Endereco != null)
                {
                    pacienteBuscado.Endereco = pacienteAtualizado.Endereco;
                }

                if (pacienteAtualizado.Telefone != null)
                {
                    pacienteBuscado.Telefone = pacienteAtualizado.Telefone;
                }
            }
           
            ctx.Pacientes.Update(pacienteBuscado);
            ctx.SaveChanges();
        }

        public Paciente BuscarPorId(int id)
        {
            return ctx.Pacientes.Include(p => p.IdusuariosNavigation).Select(p => new Paciente
            {
                Idpacientes = p.Idpacientes,
                Idusuarios = p.Idusuarios,
                Nome = p.Nome,
                DataNascimento = p.DataNascimento,
                Telefone = p.Telefone,
                Rg = p.Rg,
                Cpf = p.Cpf,
                Endereco = p.Endereco,
                IdusuariosNavigation = new Usuario
                {
                    IdtiposUsuarios = p.IdusuariosNavigation.IdtiposUsuarios,
                    Idusuarios = p.IdusuariosNavigation.Idusuarios,
                    Email = p.IdusuariosNavigation.Email
                }


            }).FirstOrDefault(p => p.Idpacientes == id);
        }

        public void Cadastrar(Paciente novoPaciente)
        {
            ctx.Pacientes.Add(novoPaciente);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Pacientes.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Paciente> ListarTudo()
        {
            return ctx.Pacientes.Include(p => p.IdusuariosNavigation).Select(p => new Paciente 
            {
                Idpacientes = p.Idpacientes,
                Idusuarios = p.Idusuarios,
                Nome = p.Nome,
                DataNascimento = p.DataNascimento,
                Telefone = p.Telefone,
                Rg = p.Rg,
                Cpf = p.Cpf,
                Endereco = p.Endereco,
                IdusuariosNavigation = new Usuario
                {
                    IdtiposUsuarios = p.IdusuariosNavigation.IdtiposUsuarios,
                    Idusuarios = p.IdusuariosNavigation.Idusuarios,
                    Email = p.IdusuariosNavigation.Email
                }
                

            }).ToList();
        }
    }
}
