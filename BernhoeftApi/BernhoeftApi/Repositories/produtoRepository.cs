using BernhoeftApi.Contexts;
using BernhoeftApi.Domains;
using BernhoeftApi.Interfaces;
using BernhoeftApi.Model.InputModels.Produto;
using Microsoft.EntityFrameworkCore;

namespace BernhoeftApi.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        BernhoeftContext ctx = new BernhoeftContext();

        public void Atualizar(int id, AtualizarProdutoInputModel produtoAtualizado)
        {
            Produto produtoBuscado = ctx.Produtos.Find(id);

            if (produtoAtualizado.Nome != null)
            {
                produtoAtualizado.Nome = produtoAtualizado.Nome;
            }

            if (produtoAtualizado.Descricao != null)
            {
                produtoBuscado.Descricao = produtoAtualizado.Descricao;
            }

            if (produtoAtualizado != null)
            {
                produtoBuscado.Preco = produtoAtualizado.Preco;
            }

            if (produtoAtualizado != null)
            {
                produtoBuscado.Situacao = produtoAtualizado.Situacao;
            }

            ctx.Produtos.Update(produtoBuscado);

            ctx.SaveChanges();

        }

        public List<Produto> BuscarPorDescricao(string descricao)
        {
            return ctx.Produtos.Where(s => s.Descricao == descricao).ToList();
        }

        public Produto? BuscarPorId(int id)
        {
            return ctx.Produtos.Select(s => new Produto()
                {
                    ProdutoId = s.ProdutoId,
                    CategoriaId = s.CategoriaId,
                    UsuarioId = s.UsuarioId,
                    Nome = s.Nome,
                    Descricao = s.Descricao,
                    Preco = s.Preco,
                    Situacao = s.Situacao,
            })
                .FirstOrDefault(s => s.ProdutoId == id);
        }

        public List<Produto> BuscarPorCategoria(int id)
        {
            return ctx.Produtos.Where(s => s.CategoriaId == id).ToList();
        }

        public List<Produto> BuscarPorSitucao(bool situcao)
        {
            return ctx.Produtos.Where(s => s.Situacao == situcao).ToList();
        }

        public void Cadastrar(Produto novoProduto)
        {
            ctx.Produtos.Add(novoProduto);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Produtos.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Produto> Listar()
        {
            return ctx.Produtos.ToList();
        }


        public List<Produto> ListarMeusProdutos(int UsuarioId)
        {
            return ctx.Produtos

             .ToList();
        }
    }
}
