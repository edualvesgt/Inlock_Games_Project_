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
    public class TipoUsuariosController : ControllerBase
    {

        private ITipoUsuariosRepository _tipoUsuariosRepository { get; set; }


        public TipoUsuariosController()
        {
            _tipoUsuariosRepository = new TipoUsuariosRepository();
        }


        [HttpGet]
        [Authorize(Roles = "2")]

        public IActionResult GetListarTodos()
        {
            try
            {
                List<TipoUsuariosDomain> listaTipoUsuarios = _tipoUsuariosRepository.ListarTodos();


                return StatusCode(200, listaTipoUsuarios);

            }

            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }




        [HttpPost]
        [Authorize(Roles = "2")]

        public IActionResult PostCadastrar(TipoUsuariosDomain novoTipoUsuario)
        {

            try
            {

                _tipoUsuariosRepository.Cadastrar(novoTipoUsuario);

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
                _tipoUsuariosRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


    }
}
