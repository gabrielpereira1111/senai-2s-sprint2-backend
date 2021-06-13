using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using senai.spmed.webApi.Contexts;
using senai.spmed.webApi.Domains;
using senai.spmed.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmed.webApi.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        SPMedContext ctx = new SPMedContext();
        public void Atualizar(int id, Consulta consultaAtualizada)
        {
            Consulta consultaBuscada = ctx.Consultas.Find(id);
            if (consultaBuscada != null)
            {
                if (consultaAtualizada.Idmedicos != null)
                {
                    consultaBuscada.Idmedicos = consultaAtualizada.Idmedicos;
                }

                consultaBuscada.DataConsulta = consultaAtualizada.DataConsulta;
            }

            ctx.Consultas.Update(consultaBuscada);
            ctx.SaveChanges();
        }

        public void atualizarSituacao(int id, string situacao)
        {
            Consulta consultaBuscada = ctx.Consultas
                .Include(c => c.IdmedicosNavigation)
                .Include(c => c.IdpacientesNavigation)
                .FirstOrDefault(c => c.Idconsultas == id);


            switch (situacao)
            {
                case "1":
                    consultaBuscada.Situacao = "Realizada";
                    break;
                case "2":
                    consultaBuscada.Situacao = "Cancelada";
                    break;
                case "3":
                    consultaBuscada.Situacao = "Agendada";
                    break;
                default:
                    consultaBuscada.Situacao = "Agendada";
                    break;
            }

            ctx.Consultas.Update(consultaBuscada);
            ctx.SaveChanges();
        }

        public Consulta BuscarPorId(int id)
        {
            return ctx.Consultas
                .Include(c => c.IdmedicosNavigation)
                .Include(c => c.IdpacientesNavigation)
                .FirstOrDefault(c => c.Idconsultas == id);
        }

        public void Cadastrar(Consulta novaConsulta)
        {
            ctx.Consultas.Add(novaConsulta);
            ctx.SaveChanges();

        }

        public void Deletar(int id)
        {
            ctx.Consultas.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public void descricaoConsulta(int id, Consulta descricao)
        {
            Consulta consultaBuscada = ctx.Consultas
                .Include(c => c.IdmedicosNavigation)
                .Include(c => c.IdpacientesNavigation)
                .FirstOrDefault(c => c.Idconsultas == id);


            if (consultaBuscada != null)
            {
                consultaBuscada.descricao = descricao.descricao;
            }

            ctx.Consultas.Update(consultaBuscada);
            ctx.SaveChanges();


        }

        public List<Consulta> listarMedicos(int id)
        {
            return ctx.Consultas
                .Include(c => c.IdpacientesNavigation)
                .Where(c => c.Idmedicos == id)
                .ToList();
        }

        public List<Consulta> listarPacientes(int id)
        {
            return ctx.Consultas
                .Include(c => c.IdmedicosNavigation)
                .Where(c => c.IdpacientesNavigation.Idusuarios == id)
                .ToList();
        }

        public List<Consulta> ListarTudo()
        {
            return ctx.Consultas
                .Include(c => c.IdmedicosNavigation)
                .Include(c => c.IdpacientesNavigation)
                .Select(c => new Consulta
                {
                    Idconsultas = c.Idconsultas,
                    Idmedicos = c.Idmedicos,
                    Idpacientes = c.Idpacientes,
                    DataConsulta = c.DataConsulta,
                    Situacao = c.Situacao,
                    IdmedicosNavigation = new Medico
                    {
                        Idmedicos = c.IdmedicosNavigation.Idmedicos,
                        Nome = c.IdmedicosNavigation.Nome,
                        IdespecialidadesNavigation = new Especialidade
                        {
                            Idespecialidades = c.IdmedicosNavigation.IdespecialidadesNavigation.Idespecialidades,
                            Nome = c.IdmedicosNavigation.IdespecialidadesNavigation.Nome
                        }
                    },
                    IdpacientesNavigation = new Paciente
                    {
                        Idpacientes = c.IdpacientesNavigation.Idpacientes,
                        Idusuarios = c.IdpacientesNavigation.Idusuarios,
                        Nome = c.IdpacientesNavigation.Nome
                    }
                })
                .ToList();

        }
    }
}
