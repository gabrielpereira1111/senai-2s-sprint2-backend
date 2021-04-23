using Microsoft.EntityFrameworkCore;
using senai.locadora.webApi.Context;
using senai.locadora.webApi.Domains;
using senai.locadora.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.locadora.webApi.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {

        LocadoraContext ctx = new LocadoraContext();
        public void Atualizar(int id, Empresa empresaAtualizada)
        {
            Empresa empresaBuscada = ctx.Empresas.Find(id);
            if (empresaBuscada.Endereco != null && empresaBuscada.Cnpj != null)
            {
                empresaBuscada.Endereco = empresaAtualizada.Endereco;
                empresaBuscada.Cnpj = empresaAtualizada.Endereco;
            }
            ctx.Empresas.Update(empresaAtualizada);
            ctx.SaveChanges();
        }

        public Empresa BuscarPorId(int id)
        {
            return ctx.Empresas.FirstOrDefault(e => e.IdEmpresa == id);
        }

        public void Cadastrar(Empresa novaEmpresa)
        {
            ctx.Empresas.Add(novaEmpresa);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Empresa empresaBuscada = ctx.Empresas.Find(id);
            ctx.Empresas.Remove(empresaBuscada);
            ctx.SaveChanges();
        }

        public List<Empresa> ListarTudo()
        {
            return ctx.Empresas.ToList();
        }

        public List<Empresa> ListaVeiculos()
        {
            return ctx.Empresas.Include(e => e.Veiculos).ToList();
        }
    }
}
