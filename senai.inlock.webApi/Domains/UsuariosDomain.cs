using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi_.Domains
{
    public class UsuariosDomain
    {

        public int IdUsuario { get; set; }


        [Required (ErrorMessage = "O tipo de Usuario e obrigatorio" )]
        public int IdTipoUsuario { get; set; }


        [Required (ErrorMessage = "O email do usuario e obrigatorio!")]
        public string Email { get; set; }


        [Required (ErrorMessage = "A senha do usuario e obrigatoria!")]
        public string Senha { get; set; }


        public TipoUsuariosDomain TipoUsuarios { get; set; }


    }
}
