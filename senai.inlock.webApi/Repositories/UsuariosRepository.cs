using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi_.Repositories
{
    public class UsuariosRepository : IUsuarioRepository
    {


       
        private string stringConexao = "Data Source = NOTE15-S15; Initial Catalog = inlock_games; User Id = sa; pwd = Senai@134";15

        public UsuariosDomain BuscarPorLogin(string Email, string Senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT * FROM Usuario WHERE Email = @Email AND Senha = @Senha";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@Email", Email);

                    cmd.Parameters.AddWithValue("@Senha", Senha);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuariosDomain usuarioBuscado = new UsuariosDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),

                            Email = rdr["Email"].ToString(),

                            Senha = rdr["Senha"].ToString(),

                            TipoUsuarios = new TipoUsuariosDomain()
                            {
                                IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),

                                Titulo = rdr[0].ToString(),
                            }
                        };

                        return usuarioBuscado;
                    }

                    return null;
                }
            }
        }


        public UsuariosDomain Login(string Email, string Senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryLogin = "SELECT Email, Senha, IdTipoUsuario FROM Usuario WHERE Email = @Email AND @Senha = @Senha";

                SqlDataReader rdr;

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@Email", Email);

                    cmd.Parameters.AddWithValue("@Senha", Senha);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuariosDomain usuarios = new UsuariosDomain()
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),

                            Email = rdr["Email"].ToString(),

                            Senha = rdr["Senha"].ToString(),

                            TipoUsuarios = new TipoUsuariosDomain()
                            {
                                IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),

                                Titulo = rdr[0].ToString(),
                            }
                        };

                        return usuarios;
                    }

                    return null;

                }
            }
        }
    }
}
