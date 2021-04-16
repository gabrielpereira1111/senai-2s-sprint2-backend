using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Domains;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class FuncionariosRepository : IFuncionariosRepository
    {
        string stringConexao = "Data Source = DSK_PHD001\\SQLEXPRESS; initial catalog = M_Peoples; user Id = sa; pwd = senai@132";
        public void Atualizar(FuncionariosDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Funcionarios SET Nome = @Nome, Sobrenome = @Sobrenome WHERE idFuncionarios = @ID";
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);
                    cmd.Parameters.AddWithValue("@ID", funcionario.idFuncionarios);

                    con.Open();
                    cmd.ExecuteNonQuery();

                }

            }
        }

        public FuncionariosDomain BuscarPorID(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectID = "SELECT * FROM Funcionarios WHERE idFuncionarios = @ID";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectID, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        FuncionariosDomain funcionariosBuscado = new FuncionariosDomain()
                        {
                            idFuncionarios = Convert.ToInt32(rdr[0])
                            , Nome = rdr[1].ToString()
                            ,Sobrenome = rdr[2].ToString()
                            ,DataNascimento = Convert.ToDateTime(rdr[3])
                        };

                        return funcionariosBuscado;
                    }

                    return null;
                }

            }
        }

        public List<FuncionariosDomain> BuscarPorNome(string nome)
        {
            List<FuncionariosDomain> listaFuncionarios = new List<FuncionariosDomain>();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryGetByName = "SELECT idFuncionarios, Nome, Sobrenome, DataNascimento FROM Funcionarios WHERE Nome = @Nome";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(queryGetByName, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        FuncionariosDomain funcionario = new FuncionariosDomain()
                        {
                            idFuncionarios = Convert.ToInt32(rdr["idFuncionarios"]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString(),
                            DataNascimento = Convert.ToDateTime("DataNascimento")
                        };

                        listaFuncionarios.Add(funcionario);

                    }

                    return listaFuncionarios;


                }

            }

        }

        public void Cadastrar(FuncionariosDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Funcionarios (Nome, Sobrenome, DataNascimento) VALUES (@Nome, @Sobrenome, @DataNascimento)";
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);
                    cmd.Parameters.AddWithValue("@DataNascimento",funcionario.DataNascimento);
                    con.Open();
                    cmd.ExecuteNonQuery();

                }

            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Funcionarios WHERE idFuncionarios = @ID";
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FuncionariosDomain> listarNomeCompleto()
        {
            List<FuncionariosDomain> listaFuncionarios = new List<FuncionariosDomain>();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryGetFullName = "SELECT idFuncionarios, CONCAT(Nome,' ',Sobrenome) AS [Nome Completo], DataNascimento FROM Funcionarios";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(queryGetFullName, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        FuncionariosDomain funcionarios = new FuncionariosDomain()
                        {

                            idFuncionarios = Convert.ToInt32(rdr["idFuncionarios"]),
                            Nome = rdr[1].ToString(),
                            DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])

                        };

                        listaFuncionarios.Add(funcionarios);

                    }

                }

                return listaFuncionarios;

            }
        }

        public List<FuncionariosDomain> listarOrdenacao(string ordem)
        {
            List<FuncionariosDomain> listaOrdenacao = new List<FuncionariosDomain>();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryGetByOrder = "SELECT IdFuncionarios, Nome, Sobrenome, DataNascimento " +
                                        $"FROM Funcionarios ORDER BY Nome {ordem}";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(queryGetByOrder, con))
                {
                    
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        FuncionariosDomain funcionarios = new FuncionariosDomain()
                        {
                            idFuncionarios = Convert.ToInt32(rdr["idFuncionarios"]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString(),
                            DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])

                        };

                        listaOrdenacao.Add(funcionarios);

                    }

                }

                return listaOrdenacao;

            }
        }

        public List<FuncionariosDomain> ListarTudo()
        {
            List<FuncionariosDomain> listaFuncionarios = new List<FuncionariosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM Funcionarios";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        FuncionariosDomain funcionarios = new FuncionariosDomain()
                        {
                            idFuncionarios = Convert.ToInt32(rdr[0]),
                            Nome = rdr[1].ToString(),
                            Sobrenome = rdr[2].ToString(),
                            DataNascimento = Convert.ToDateTime(rdr[3])
                            
                        };

                        listaFuncionarios.Add(funcionarios);

                    
                    }


                }
            }

            return listaFuncionarios;
        }
    }
}
