using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi_.Interfaces
{
    public interface IUsuarioRepository
    {

        public UsuariosDomain Login(string Email, string Senha);


        UsuariosDomain BuscarPorLogin(string Email, string Senha);

    }
}
