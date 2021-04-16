using senai_filmes_WebApi.Domain;
using senai_filmes_WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source = DSK_PHD001\\SQLEXPRESS; initial catalog = Filmes; user Id = sa; pwd=senai@132";
        public UsuarioDomain Login(string email, string senha)
        {

            
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryLogin = "SELECT idUsuario, email, senha, tipoUsuario FROM Usuarios WHERE email = @Email AND senha = @Senha";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            email = rdr["email"].ToString(),
                            senha = rdr["senha"].ToString(),
                            tipoUsuario = rdr["tipoUsuario"].ToString()
                        };

                        return usuario;
                    }

                    return null;

                }

            }
        }

      
    }
}
