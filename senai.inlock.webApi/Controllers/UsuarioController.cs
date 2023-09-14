using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai.inlock.webApi_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private IUsuarioRepository _usuarioRepository { get; set; }


        public UsuarioController()
        {
            _usuarioRepository = new UsuariosRepository();
        }



        [HttpPost]

        public IActionResult PostLogin(UsuariosDomain usuarioLogin)
        {

            try
            {

                UsuariosDomain usuario = _usuarioRepository.Login(usuarioLogin.Email, usuarioLogin.Senha);

                if (usuario == null)
                {
                    return BadRequest("Usuario nao encontrado");
                }



                //1º Definir as informacoes(Claims) que serao fornecidos no token (PAYLOAD)
                var claims = new[]
                {

                    
                    new Claim(JwtRegisteredClaimNames.Jti,usuario.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.IdTipoUsuario.ToString())


                    //Existe a possibilidade de criar uma claim personalizada
                    //new Claim("Claim Personalizada", "Valor da Claim Personalizada")
                };


                //2º - Definir a chave de acesso do token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-games-chave-autenticacao-webapi-dev"));


                //3º - Definir as credenciais do token(HEADER)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4º - Gerar token
                var token = new JwtSecurityToken
                    (
                        //Emissor do token
                        issuer: "inlock_games",

                        //Destinatario
                        audience: "inlock_games",

                        //dados definidos nas claims(informacoes)
                        claims: claims,

                        //Tempo de expiracao do token
                        expires: DateTime.Now.AddMinutes(5),

                        //credenciais do token
                        signingCredentials: creds
                    );

                //5º - Retirnar o token criado
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });


            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }







        [HttpGet]
        [Authorize(Roles = "2")]

        public IActionResult GetBuscarPorLogin(string Email, string Senha)
        {
            try
            {
                UsuariosDomain usuarioBuscado = _usuarioRepository.BuscarPorLogin(Email, Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("Nenhum Usuario foi encontrado");
                }

                return Ok(usuarioBuscado);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

    }
}
