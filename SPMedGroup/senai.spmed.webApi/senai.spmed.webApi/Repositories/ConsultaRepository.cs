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
    public class ConsultaRepository : IConsultaRepository
    {
        SPMedContext ctx = new SPMedContext();
        public void Atualizar(int id, Consulta consultaAtualizada)
        {
            throw new NotImplementedException();
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
                    consultaBuscada.Situacao = consultaBuscada.Situacao;
                    break;
            }

            ctx.Consultas.Update(consultaBuscada);
            ctx.SaveChanges();
        }

        public Consulta BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Consulta novaConsulta)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
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
                .Where(c => c.Idpacientes == id)
                .ToList();
        }

        public List<Consulta> ListarTudo()
        {
            throw new NotImplementedException();
        }
    }
}
