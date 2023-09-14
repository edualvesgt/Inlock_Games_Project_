using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi_.Domains
{
    public class TipoUsuariosDomain
    {
        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "O tipo do usuario e obrigatorio!")]
        public string Titulo { get; set; }
    }
}
