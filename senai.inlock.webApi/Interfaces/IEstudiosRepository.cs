using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi_.Interfaces
{
    public interface IEstudiosRepository
    {

        /// <summary>
        /// Cadastrar um novo estudio
        /// </summary>
        /// <param name="novoEstudio">objeto que sera cadastrado</param>
        void Cadastrar(EstudiosDomain novoEstudio);


        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        List<EstudiosDomain> ListarTodosEstudios();


        /// <summary>
        /// Deletar um objeto
        /// </summary>
        /// <param name="id">id do objeto que sera deletado</param>
        void Deletar(int id);

        
        /// <summary>
        /// Buscar objeto atraves do Id
        /// </summary>
        /// <param name="id">Id do objeto a ser buscado</param>
        /// <returns>Objeto buscado</returns>
        EstudiosDomain BuscarPorId(int id);

    }
}
