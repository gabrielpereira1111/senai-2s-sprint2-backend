using senai.locadora.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.locadora.webApi.Interfaces
{
    interface IEmpresaRepository
    {
        /// <summary>
        /// Lista todas as empresas
        /// </summary>
        /// <returns>Lista de empresas</returns>
        List<Empresa> ListarTudo();
        /// <summary>
        /// Buscar empresa por id
        /// </summary>
        /// <param name="id">id da empresa</param>
        /// <returns>empresa buscada</returns>
        Empresa BuscarPorId(int id);
        /// <summary>
        /// Cadastra uma nova empresa
        /// </summary>
        /// <param name="novaEmpresa"> Credenciais de cadastro da empresa</param>
        void Cadastrar(Empresa novaEmpresa);
        /// <summary>
        /// Atualizar dados da empresa
        /// </summary>
        /// <param name="id"> id da empresa que será atualizada</param>
        /// <param name="empresaAtualizada">dados que serão atualizados</param>
        void Atualizar(int id,Empresa empresaAtualizada);
        /// <summary>
        /// Deletar empresa
        /// </summary>
        /// <param name="id"> id da empresa que será deletada</param>
        void Deletar(int id);

        List<Empresa> ListaVeiculos();
    }
}
