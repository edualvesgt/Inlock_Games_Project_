using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;
using System.Data;

namespace senai.inlock.webApi_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //Define que o tipo de resposta da API sera no formato JSON
    [Produces("application/json")]
    public class EstudioController : ControllerBase
    {

        private IEstudiosRepository _estudioRepository { get; set; }


        public EstudioController()
        {
            _estudioRepository = new EstudiosRepository();
        }


    
        [HttpGet]

        public IActionResult GetListarTodosEstudios()
        {
            try
            {
                List<EstudiosDomain>
                    listaEstudios = _estudioRepository.ListarTodosEstudios();


                return StatusCode(200, listaEstudios);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }



   
        [HttpPost]
        [Authorize(Roles = "2")]

        public IActionResult PostCadastrar(EstudiosDomain novoEstudio)
        {

            try
            {
   
                _estudioRepository.Cadastrar(novoEstudio);

                return StatusCode(201);

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }



        [HttpDelete("{@Id}")]
        [Authorize(Roles = "2")]

        public IActionResult DeleteDeletar(int id)
        {
            try
            {
                _estudioRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


  
        [HttpGet("{id}")]

        public IActionResult GetBuscarPorId(int id)
        {
            try
            {

                EstudiosDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

                if (estudioBuscado == null)
                {
                    return NotFound("Nenhum Estudio foi encontrado");
                }

                return Ok(estudioBuscado);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


    }
}
