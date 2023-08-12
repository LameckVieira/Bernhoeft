using BernhoeftApi.Domains;
using BernhoeftApi.Model.InputModels.TipoUsuario;

namespace BernhoeftApi.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista todos os tipoUsuario
        /// </summary>
        /// <returns>Uma lista de tipoUsuario</returns>
        List<TipoUsuario> Listar();

        /// <summary>
        /// Busca um usuario através do seu ID
        /// </summary>
        /// <param name="id">ID do usuario que será buscado</param>
        /// <returns>Um usuario buscado</returns>
        TipoUsuario BuscarPorId(int id);


        /// <summary>
        /// Busca um usuario pelo nome
        /// </summary>
        /// <param name="tipoUsuario"> tipousuario que será buscado</param>
        /// <returns>Um tipousuario buscado</returns>
        TipoUsuario BuscarPeloTipo(string tipoUsuario);

        /// <summary>
        /// Cadastra um novo tipousuario
        /// </summary>
        /// <param name="novousuario">Objeto novotipousuario que será cadastrado</param>
        void Cadastrar(TipoUsuario novotipoUsuario);

        /// <summary>
        /// Atualiza um usuario existente
        /// </summary>
        /// <param name="id">ID do usuario que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto usuarioAtualizado com as novas informações</param>
        void Atualizar(int id, AtualizarTipoUsuarioInputModel tipoUsuarioAtualizado);

        /// <summary>
        /// Deleta um usuario existente
        /// </summary>
        /// <param name="id">ID do usuario que será deletado</param>
        void Deletar(int id);
    }
}
