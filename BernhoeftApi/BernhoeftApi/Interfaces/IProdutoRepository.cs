using BernhoeftApi.Domains;
using BernhoeftApi.Model.InputModels.Produto;
using BernhoeftApi.Model.InputModels.TipoUsuario;

namespace BernhoeftApi.Interfaces
{
    public interface IProdutoRepository
    {
        /// <summary>
        /// Lista todos os produtos
        /// </summary>
        /// <returns>Uma lista de produto</returns>
        List<Produto> Listar();

        /// <summary>
        /// Cadastra um novo produto
        /// </summary>
        /// <param name="novoProduto">Objeto novoprodutoque será cadastrado</param>
        void Cadastrar(Produto novoProduto);

        /// <summary>
        /// Deleta um produto existente
        /// </summary>
        /// <param name="id">ID da produto que será deletada</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza um produto existente
        /// </summary>
        /// <param name="id">Id da produto que será atualizado</param>
        /// <param name="produtoAtualizado">Objeto salaAtualizada que receberá os novos valores</param>
        void Atualizar(int id, AtualizarProdutoInputModel produtoAtualizado);

        /// <summary>
        /// Buscar uma produto por seu id
        /// </summary>
        /// <param name="id">id da produto a ser buscado</param>
        /// <returns>uma produto buscado</returns>
        Produto BuscarPorId(int id);

        List<Produto> BuscarPorSitucao(bool situcao);

        List<Produto> BuscarPorDescricao(string descricao);

        List<Produto> BuscarPorCategoria(int id);

        List<Produto> ListarMeusProdutos(int IdUsuario);
    }
}
