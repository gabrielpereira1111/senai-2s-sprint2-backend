using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Domains;

namespace WebApplication1.Interfaces
{
    interface IFuncionariosRepository
    {
        List<FuncionariosDomain> ListarTudo();
        FuncionariosDomain BuscarPorID(int id);
        List<FuncionariosDomain> BuscarPorNome(string nome);
        void Cadastrar(FuncionariosDomain funcionario);
        void Atualizar(FuncionariosDomain funcionario);
        void Deletar(int id);
        List<FuncionariosDomain> listarNomeCompleto();
        List<FuncionariosDomain> listarOrdenacao(string ordem);
    }
}
