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
    public class ClinicaRepository : IClinicaRepository
    {
        SPMedContext ctx = new SPMedContext();
        public void Atualizar(int id, Clinica clinicaAtualizada)
        {
            Clinica clinicaBuscada = BuscarPorId(id);

            if (clinicaBuscada != null)
            {
                if (clinicaAtualizada.Endereco != null)
                {
                    clinicaBuscada.Endereco = clinicaAtualizada.Endereco;
                }
                if (clinicaAtualizada.NomeFantasia != null)
                {
                    clinicaBuscada.NomeFantasia = clinicaAtualizada.NomeFantasia;
                }
                if (clinicaAtualizada.RazaoSocial != null)
                {
                    clinicaBuscada.RazaoSocial = clinicaAtualizada.RazaoSocial;
                }
            }

            ctx.Clinicas.Update(clinicaBuscada);
            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(int id)
        {
            return ctx.Clinicas.Include(c => c.Medicos).FirstOrDefault(c => c.Idclinicas == id);
        }

        public void Cadastrar(Clinica novaClinica)
        {
            ctx.Clinicas.Add(novaClinica);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Clinicas.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Clinica> ListarTudo()
        {
            return ctx.Clinicas.Include(c => c.Medicos).ToList();
        }
    }
}
