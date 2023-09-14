using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi_.Repositories
{
    public class EstudiosRepository : IEstudiosRepository
    {

        private string stringConexao = "Data Source = NOTE15-S15; Initial Catalog = inlock_games; User Id = sa; pwd = Senai@134";


        public EstudiosDomain BuscarPorId(int id)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT IdEstudio, Nome FROM Estudio WHERE IdEstudio = @IdEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        EstudiosDomain estudioBuscado = new EstudiosDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                            Nome = rdr["Nome"].ToString(),
                        };

                        return estudioBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(EstudiosDomain novoEstudio)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Estudio(Nome) VALUES(@Nome)";

                con.Open();

                using(SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoEstudio.Nome);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection (stringConexao))
            {
                string queryDelete = "DELETE From Estudio WHERE @id = IdEstudio";

                con.Open ();

                using (SqlCommand cmd = new SqlCommand (queryDelete, con))
                {
                    cmd.Parameters.AddWithValue ("@id", id);

                    cmd.ExecuteNonQuery ();
                }
            }
        }

        public List<EstudiosDomain> ListarTodosEstudios()
        {
            List<EstudiosDomain> listaEstudios = new List<EstudiosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdEstudio, Nome FROM Estudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudiosDomain estudio = new EstudiosDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                            Nome = rdr["Nome"].ToString(),
                        };

                        listaEstudios.Add(estudio);
                    }
                }
            }

            return listaEstudios;

        }
    }
}
