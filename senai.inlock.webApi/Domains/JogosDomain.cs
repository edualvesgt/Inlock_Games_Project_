using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi_.Domains
{
    public class JogosDomain
    {

        public int IdJogo { get; set; }


        [Required (ErrorMessage = "O Estudio e obrigatorio!")]

        public int IdEstudio { get; set; }


        [Required (ErrorMessage = "O Nome do jogo e obrigatorio!")]
        public string Nome { get; set; }


        public string Descricao { get; set; }


        [Required (ErrorMessage = "A data de lancamento e obrigatoria!")]

        public DateTime DataLancamento { get;set; }


        [Required (ErrorMessage = "o valor do jogo e obrigatorio!")]

        public Decimal Valor { get; set; }


        public EstudiosDomain Estudio { get; set; }
    }
}
