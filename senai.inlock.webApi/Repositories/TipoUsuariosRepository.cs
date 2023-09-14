using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi_.Repositories
{
    public class TipoUsuariosRepository : ITipoUsuariosRepository
    {

        private string stringConexao = "Data Source = NOTE15-S15; Initial Catalog = inlock_games; User Id = sa; pwd = Senai@134";


        public void Cadastrar(TipoUsuariosDomain novoTipoUsuario)
        {
           
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
               
                string queryInsert = "INSERT INTO TiposUsuario(Titulo) VALUES (@Titulo)";


                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", novoTipoUsuario.Titulo);

                    
                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            };
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM TiposUsuario WHERE @id = IdTipoUsuario";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<TipoUsuariosDomain> ListarTodos()
        {
            List<TipoUsuariosDomain> listaTipoUsuario = new List<TipoUsuariosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdTipoUsuario, Titulo FROM TiposUsuario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TipoUsuariosDomain TipoUsuarios = new TipoUsuariosDomain()
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),

                            Titulo = rdr["Titulo"].ToString(),
                        };

                        listaTipoUsuario.Add(TipoUsuarios);
                    }
                }
            }

            return listaTipoUsuario;

        }

    }
}
