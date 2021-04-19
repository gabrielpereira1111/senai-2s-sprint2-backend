using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        string stringConexao = "Data Source = DSK_PHD001\\SQLEXPRESS; initial catalog = inlock_games_manha; user Id = sa; pwd = senai@132 ";
        public void Cadastrar(JogoDomain novoJogo)
        {
            throw new NotImplementedException();
        }

        public List<JogoDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
