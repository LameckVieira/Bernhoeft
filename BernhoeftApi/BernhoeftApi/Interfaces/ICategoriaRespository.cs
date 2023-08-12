using BernhoeftApi.Domains;

namespace BernhoeftApi.Interfaces
{
    public interface ICategoriaRespository
    {
        /// <summary>
        /// Lista todas as categorias
        /// </summary>
        /// <returns>Uma lista de categoria</returns>
        List<Categoria> Listar();

        /// <summary>
        /// Cadastra uma nova categoria
        /// </summary>
        /// <param name="novoProduto">Objeto novacategoria que será cadastrado</param>
        void Cadastrar(Categoria novaCategoria);

        /// <summary>
        /// Deleta um categoria existente
        /// </summary>
        /// <param name="id">ID da categoria que será deletada</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza uma categoria existente
        /// </summary>
        /// <param name="id">Id da categoria que será atualizado</param>
        /// <param name="categoriaAtualizado">Objeto salaAtualizada que receberá os novos valores</param>
        void Atualizar(int id, Categoria categoriaAtualizado);

        /// <summary>
        /// Buscar uma categoria por seu id
        /// </summary>
        /// <param name="id">id da categoria a ser buscado</param>
        /// <returns>uma categoria buscado</returns>
        Categoria BuscarPorId(int id);
        Categoria BuscarPorSitucao(bool situcao);
        Categoria BuscarPorDescricao(string Nome);
        List<Categoria> ListarMinhasCategorias(int IdUsuario);
    }
}
