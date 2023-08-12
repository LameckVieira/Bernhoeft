using BernhoeftApi.Contexts;
using BernhoeftApi.Domains;
using BernhoeftApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BernhoeftApi.Repositories
{
    public class categoriaRepository : ICategoriaRespository
    {
        BernhoeftContext ctx = new BernhoeftContext();
        public void Atualizar(int id, Categoria categoriaAtualizada)
        {
            Categoria categoriaBuscada = ctx.Categorias.Find(id);

            if (categoriaAtualizada.Nome != null)
            {
                categoriaAtualizada.Nome = categoriaAtualizada.Nome;
            }

            if (categoriaAtualizada != null)
            {
                categoriaBuscada.Situacao = categoriaAtualizada.Situacao;
            }

            ctx.Categorias.Update(categoriaBuscada);

            ctx.SaveChanges();
        }

        public Categoria? BuscarPorId(int id)
        {
            return ctx.Categorias.Select(s => new Categoria()
            {
                IdCategoria = s.IdCategoria,
                IdUsuario = s.IdUsuario,
                Nome = s.Nome,
                Situacao = s.Situacao,
            })
                .FirstOrDefault(s => s.IdCategoria == id);
        }

        public Categoria? BuscarPorSitucao(bool situcao)
        {
            return ctx.Categorias.Select(s => new Categoria()
            {
                IdCategoria = s.IdCategoria,
                IdUsuario = s.IdUsuario,
                Nome = s.Nome,
                Situacao = s.Situacao,
            })
                .FirstOrDefault(s => s.Situacao == situcao);
        }

        public Categoria? BuscarPorDescricao(string nome)
        {
            return ctx.Categorias.Select(s => new Categoria()
            {
                IdCategoria = s.IdCategoria,
                IdUsuario = s.IdUsuario,
                Nome = s.Nome,
                Situacao = s.Situacao,
            })
                .FirstOrDefault(s => s.Nome == nome);
        }

        public void Cadastrar(Categoria novaCategoria)
        {
            ctx.Categorias.Add(novaCategoria);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Categorias.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Categoria> Listar()
        {
            return ctx.Categorias.ToList();
        }

        public List<Categoria> ListarMinhasCategorias(int IdUsuario)
        {
            return ctx.Categorias

             .Include(c => c.IdUsuarioNavigation)

             .Where(c => c.IdUsuarioNavigation.IdUsuario == IdUsuario)

             .ToList();
        }
    }
}
