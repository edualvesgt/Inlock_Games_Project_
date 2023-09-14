using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;

namespace senai.inlock.webApi_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //Define que o tipo de resposta da API sera no formato JSON
    [Produces("application/json")]
    public class JogosController : ControllerBase
    {


        private IJogosRepository _jogoRepository { get; set; }


        public JogosController()
        {
            _jogoRepository = new JogosRepository();
        }


        /// <summary>
        /// EndPoint que aciona o metodo ListarTodosJogos no repositorio e retorna a resposta para o usuario(Front-End)
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        public IActionResult GetListarTodosJogos()
        {
            try
            {
                List<JogosDomain>
                    listaJogos = _jogoRepository.ListarTodosJogos();


                return StatusCode(200, listaJogos);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// EndPoint que aciona o metodo de buscar por id
        /// </summary>
        /// <param name="id">Id do objeto a ser buscado</param>
        /// <returns>Status code e objeto caso encontrado</returns>
        [HttpGet("{id}")]

        public IActionResult GetBuscarPorId(int id)
        {
            try
            {
                //Cria um objeto jogoBuscado que ira receber o jogo buscado no banco de dados
                JogosDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

                if (jogoBuscado == null)
                {
                    return NotFound("Nenhum jogo foi encontrado");
                }

                return Ok(jogoBuscado);
            }
            catch (Exception erro)
            {
                //Retorna com status code BadRequest(400) e a mensagem do erro
                return BadRequest(erro.Message);
            }
        }



    }
}
