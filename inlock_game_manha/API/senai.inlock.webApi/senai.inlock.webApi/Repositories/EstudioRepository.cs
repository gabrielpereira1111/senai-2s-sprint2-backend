using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        string stringConexao = "Data Source = DSK_PHD001\\SQLEXPRESS; initial catalog = inlock_games_manha; user Id = sa; pwd = senai@132 ";
        public void Cadastrar(EstudioDomain novoEstudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Estudio (nomeEstudio)     VALUES      (@nomeEstudio)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeEstudio", novoEstudio.nomeEstudio);
                    con.Open();
                    cmd.ExecuteNonQuery();

                }

            }
        }

        public List<EstudioDomain> ListarTodos()
        {
            List<EstudioDomain> listaEstudio = new List<EstudioDomain>();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idEstudio, nomeEstudio FROM Estudio";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            idEstudio = Convert.ToInt32(rdr["idEstudio"]),
                            nomeEstudio = rdr["nomeEstudio"].ToString()

                        };

                        listaEstudio.Add(estudio);

                    }
                }

            }

            return listaEstudio;
        }
    }
}
