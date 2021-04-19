using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    
    public class tipoUsuarioRepository : ItipoUsuarioRepository
    {
        string stringConexao = "Data Source = DSK_PHD001\\SQLEXPRESS; initial catalog = inlock_games_manha; user Id = sa; pwd = senai@132 ";
        public void Cadastrar(tipoUsuarioDomain novoTipoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO tipoUsuario (titulo)      VALUES      (@tipoUsuario)";
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@tipoUsuario", novoTipoUsuario.titulo);
                    con.Open();
                    cmd.ExecuteNonQuery();

                }

            }
        }

        public List<tipoUsuarioDomain> ListarTodos()
        {
            List<tipoUsuarioDomain> listaTipoUsuario = new List<tipoUsuarioDomain>();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idTipoUsuario, titulo FROM tipoUsuario";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        tipoUsuarioDomain tipoUsuario = new tipoUsuarioDomain()
                        {
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),
                            titulo = rdr["titulo"].ToString()
                        };

                        listaTipoUsuario.Add(tipoUsuario);

                    }

                }
            }

            return listaTipoUsuario;
        }
    }
}
