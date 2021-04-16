using senai_filmes_WebApi.Domain;
using senai_filmes_WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_WebApi.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string stringConexao = "Data Source = DSK_PHD001\\SQLEXPRESS; initial catalog = Filmes; user Id = sa; pwd=senai@132";
        public void AtualizarIDCorpo(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateURL = "UPDATE Filmes SET Titulo = @Titulo WHERE idFilmes = @ID";
                using (SqlCommand cmd = new SqlCommand(queryUpdateURL, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", filme.titulo);
                    cmd.Parameters.AddWithValue("@ID", filme.idFilme);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void AtualizarIDURL(FilmeDomain filme, int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateURL = "UPDATE Filmes SET Titulo = '@Titulo' WHERE idFilmes = @ID";
                using (SqlCommand cmd = new SqlCommand(queryUpdateURL, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", filme.titulo);
                    cmd.Parameters.AddWithValue("@ID", filme.idFilme);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public FilmeDomain BuscarPorID(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectID = "SELECT idFilmes, idGenero, Titulo FROM Filmes WHERE idFilmes = @ID";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectID, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        FilmeDomain filmeBuscado = new FilmeDomain()
                        {
                            idFilme = Convert.ToInt32(rdr["idFilmes"]),
                            idGenero = Convert.ToInt32(rdr["idGenero"]),
                            titulo = rdr["Titulo"].ToString()
                        };

                        return filmeBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            //Declara a SqlConnection chamada con, passando a stringConexao como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Seclara a string que será executada no banco de dados
                string queryInsert = "INSERT INTO Filmes(Titulo, idGenero)  VALUES('@Titulo','@IdGenero')";

                //using - Estabelece que o comando será executado somente 1 vez
                //Declara a SqlCommand chamada cmd, passando como parâmetro a queryInsert e a con
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {

                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.titulo);
                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.idGenero);
                    //Abre a conexão com o Banco de Dados
                    con.Open();
                    //Executa a queryInsert
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Filmes WHERE idFilmes = @ID";
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FilmeDomain> ListarTudo()
        {
            List<FilmeDomain> listaFilmes = new List<FilmeDomain>();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM Filmes";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            idGenero = Convert.ToInt32(rdr[1]),
                            titulo = rdr[2].ToString(),
                            idFilme = Convert.ToInt32(rdr[0])
                        };

                        listaFilmes.Add(filme);
                    
                    }

                }

                return listaFilmes;

            }
        
        }
    }
}
