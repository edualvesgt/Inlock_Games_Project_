using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi_.Domains
{
    public class EstudiosDomain
    {

        public int IdEstudio { get; set; }


        [Required (ErrorMessage = "O nome do estudio e obrigatorio!")]

        public string Nome { get; set; }

    }
}
