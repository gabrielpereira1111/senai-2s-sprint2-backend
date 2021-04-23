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
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Jogo (nomeJogo, descricao, dataLancamento, valor, idEstudio)  VALUES      (@nomeJogo, @descricao, @dataLancamento, @valor, @idEstudio)";
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeJogo", novoJogo.nomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", novoJogo.descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento",novoJogo.dataLancamento);
                    cmd.Parameters.AddWithValue("@valor",novoJogo.valor);
                    cmd.Parameters.AddWithValue("@idEstudio",novoJogo.idEstudio);

                    con.Open();
                    cmd.ExecuteNonQuery();

                }

            }
        }

       

        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> listaJogo = new List<JogoDomain>();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, idEstudio FROM Jogo";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            idJogo = Convert.ToInt32(rdr["idJogo"]),
                            nomeJogo = rdr["nomeJogo"].ToString(),
                            descricao = rdr["descricao"].ToString(),
                            dataLancamento = Convert.ToDateTime(rdr["dataLancamento"]),
                            valor = Convert.ToDecimal(rdr["valor"]),
                            idEstudio = Convert.ToInt32(rdr["idEstudio"])
                        };

                        listaJogo.Add(jogo);

                    }

                }

            }

            return listaJogo;
        }
    }
}
