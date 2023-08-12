using BernhoeftApi.Contexts;
using BernhoeftApi.Domains;
using BernhoeftApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BernhoeftApi.Repositories
{
    public class produtoRepository : IProdutoRepository
    {
        BernhoeftContext ctx = new BernhoeftContext();

        public void Atualizar(int id, Produto produtoAtualizado)
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

        public Produto? BuscarPorDescricao(string descricao)
        {
            return ctx.Produtos.Select(s => new Produto()
            {
                IdProduto = s.IdProduto,
                IdCategoria = s.IdCategoria,
                IdUsuario = s.IdUsuario,
                Nome = s.Nome,
                Descricao = s.Descricao,
                Preco = s.Preco,
                Situacao = s.Situacao,
            })
                .FirstOrDefault(s => s.Descricao == descricao);
        }

        public Produto? BuscarPorId(int id)
        {
            return ctx.Produtos.Select(s => new Produto()
                {
                    IdProduto = s.IdProduto,
                    IdCategoria = s.IdCategoria,
                    IdUsuario = s.IdUsuario,
                    Nome = s.Nome,
                    Descricao = s.Descricao,
                    Preco = s.Preco,
                    Situacao = s.Situacao,
            })
                .FirstOrDefault(s => s.IdProduto == id);
        }

        public Produto? BuscarPorCategoria(int id)
        {
            return ctx.Produtos.Select(s => new Produto()
            {
                IdProduto = s.IdProduto,
                IdCategoria = s.IdCategoria,
                IdUsuario = s.IdUsuario,
                Nome = s.Nome,
                Descricao = s.Descricao,
                Preco = s.Preco,
                Situacao = s.Situacao,
            })
                .FirstOrDefault(s => s.IdCategoria == id);
        }

        public Produto? BuscarPorSitucao(bool situcao)
        {
            return ctx.Produtos.Select(s => new Produto()
            {
                IdProduto = s.IdProduto,
                Nome = s.Nome,
                Descricao = s.Descricao,
                Preco = s.Preco,
                Situacao = s.Situacao,
            })
                .FirstOrDefault(s => s.Situacao == situcao);
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


        public List<Produto> ListarMeusProdutos(int IdUsuario)
        {
            return ctx.Produtos

             .Include(c => c.IdUsuarioNavigation)

             .Where(c => c.IdUsuarioNavigation.IdUsuario == IdUsuario)

             .ToList();
        }
    }
}
