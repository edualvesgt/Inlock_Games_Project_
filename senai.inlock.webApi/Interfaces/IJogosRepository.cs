using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi_.Interfaces
{
    public interface IJogosRepository
    {


        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        List<JogosDomain> ListarTodosJogos();


        /// <summary>
        /// Buscar objeto atraves do Id
        /// </summary>
        /// <param name="id">Id do objeto a ser buscado</param>
        /// <returns>Objeto buscado</returns>
        JogosDomain BuscarPorId(int id);


    }
}
