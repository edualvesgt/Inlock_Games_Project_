using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi_.Interfaces
{
    public interface ITipoUsuariosRepository
    {

        /// <summary>
        /// Cadastrar um novo estudio
        /// </summary>
        /// <param name="novoTipoUsuario">objeto que sera cadastrado</param>
        void Cadastrar(TipoUsuariosDomain novoTipoUsuario);



        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        List<TipoUsuariosDomain> ListarTodos();



        /// <summary>
        /// Deletar um objeto
        /// </summary>
        /// <param name="id">id do objeto que sera deletado</param>
        void Deletar(int id);


    }
}
