using BernhoeftApi.Contexts;
using BernhoeftApi.Domains;
using BernhoeftApi.Interfaces;
using BernhoeftApi.Model.InputModels.Categoria;
using Microsoft.EntityFrameworkCore;

namespace BernhoeftApi.Repositories
{
    public class CategoriaRepository : ICategoriaRespository
    {
        BernhoeftContext ctx = new BernhoeftContext();
        public void Atualizar(int id, AtualizarCategoriaInputModel categoriaAtualizada)
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
                CategoriaId = s.CategoriaId,
                UsuarioId = s.UsuarioId,
                Nome = s.Nome,
                Situacao = s.Situacao,
            })
                .FirstOrDefault(s => s.CategoriaId == id);
        }

        public List<Categoria> BuscarPorSitucao(bool situcao)
        {
            return ctx.Categorias.Where(s => s.Situacao == situcao).ToList();
    
        }

        public List<Categoria> BuscarPorDescricao(string nome)
        {
            return ctx.Categorias.Where(s => s.Nome == nome).ToList();
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

        public List<Categoria> ListarMinhasCategorias(int UsuarioId)
        {
            return ctx.Categorias

             .ToList();
        }
    }
}
