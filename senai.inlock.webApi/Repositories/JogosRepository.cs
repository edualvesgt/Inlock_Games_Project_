using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi_.Repositories
{
    public class JogosRepository : IJogosRepository
    {

        private string stringConexao = "Data Source = NOTE15-S15; Initial Catalog = inlock_games; User Id = sa; pwd = Senai@134";


        public JogosDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT * FROM Jogo WHERE IdJogo = @Id";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        JogosDomain jogoBuscado = new JogosDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),

                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                            Nome = rdr["Nome"].ToString(),

                            Descricao = rdr["Descricao"].ToString(),

                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),

                            Valor = Convert.ToDecimal(rdr["Valor"]),

                            Estudio = new EstudiosDomain()
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                                Nome = rdr["Nome"].ToString(),
                            }
                        };

                        return jogoBuscado;

                    }

                    return null;
                }
            }
        }

        public List<JogosDomain> ListarTodosJogos()
        {
           List<JogosDomain> listaJogos = new List<JogosDomain>();

            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelecetAll = "SELECT Jogo.Nome AS Jogo, Estudio.Nome AS Estudio FROM Jogo INNER JOIN Estudio ON Jogo.IdEstudio = Estudio.IdEstudio";

                con.Open();

                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand(querySelecetAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogosDomain jogo = new JogosDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),

                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                            Nome = rdr["Nome"].ToString(),

                            Descricao = rdr["Descricao"].ToString(),

                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),

                            Valor = Convert.ToDecimal(rdr["DataLancamento"]),

                            Estudio = new EstudiosDomain()
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                                Nome = rdr["Nome"].ToString(),
                            }
                        };

                        listaJogos.Add(jogo);

                    }
                }
            }

            return listaJogos;
        }

    }
}
