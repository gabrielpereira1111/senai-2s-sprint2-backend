using senai_filmes_WebApi.Domain;
using senai_filmes_WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_WebApi.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// Data Source - nome do servidor
        /// initial catalog - nome do bando de dados
        /// user Id - nome do usuário(logon)
        /// pwd - senha do usuário
        /// </summary>
        private string stringConexao = "Data Source=DSK_PHD001\\SQLEXPRESS; initial catalog=Filmes; user Id=sa; pwd=senai@132";
        public void AtualizarCorpo(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateIDBody = "UPDATE Generos SET Nome = @Nome WHERE IdGenero = @ID";
                using (SqlCommand cmd = new SqlCommand(queryUpdateIDBody, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);
                    cmd.Parameters.AddWithValue("@ID",genero.idGenero);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void AtualizarURL(int id, GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateURL = "UPDATE Generos SET Nome = @Nome WHERE idGenero = @ID";
                using (SqlCommand cmd = new SqlCommand(queryUpdateURL, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);
                    cmd.Parameters.AddWithValue("@ID",genero.idGenero);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca pos um gênero pelo seu ID
        /// </summary>
        /// <param name="id"> ID do gênero </param>
        /// <returns> retorna o genero buscado com base em seu id </returns>
        public GeneroDomain BuscarPorId(int id)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idGenero, Nome FROM Generos WHERE idGenero = @ID";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectById,con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        GeneroDomain generoBuscado = new GeneroDomain()
                        {
                            idGenero = Convert.ToInt32(rdr["idGenero"]),
                            Nome = rdr["Nome"].ToString()
                        };
                        return generoBuscado;

                    }

                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto novoGeneto com as informações que serão cadastradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            //Declara a SqlConnection con, passando como parâmetro a stringConexao
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Generos(Nome) VALUES('"+ novoGenero.Nome +"')";
                
                //Declara a SqlCommand, passando como parâmetro a queryInsert e a con
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {

                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);
                    //Abre a conexao com o DB
                    con.Open();
                    
                    //Executa a query
                    cmd.ExecuteNonQuery();


                }
            }
            
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Generos WHERE idGenero = @ID";
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public List<GeneroDomain> ListarTudo()
        {
            //Cria uma lista chamada listaGeneros que serão armazenados os dados
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();
           //Declara a SqlConnection 'con' passando a 'stringConexao'
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM Generos";
                //Abre a conexão com o banco de dados
                con.Open();
                //Declara SqlDataReader 'rdr' para percorrer a tabela do banco de dados
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //Executa a query e armazena no rdr
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //Atribui a propriedade id genero o valor da primeira coluna do banco de dados
                            idGenero = Convert.ToInt32(rdr[0]),
                            //Atribui o valor da segunda coluna do banco de dados
                            Nome = rdr[1].ToString()

                        };
                        //Adiciona o objeto 'genero' na listaGenero
                        listaGeneros.Add(genero);

                    }
                }
               
            }
            //Retorna a lista de gêneros
            return listaGeneros;
        }
    }
}
