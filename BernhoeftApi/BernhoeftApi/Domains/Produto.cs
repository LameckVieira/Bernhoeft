using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BernhoeftApi.Domains
{
    public partial class Produto
    {
        public Produto()
        {

        }

        public Produto(int usuarioid, int categoriaId, string nome, double preco,string descricao, bool situacao)
        {
            UsuarioId = usuarioid;
            CategoriaId = categoriaId;
            Nome = nome;
            Preco = preco;
            Descricao = descricao;
            Situacao = situacao;
        }

        [Key]
        public int ProdutoId { get; set; }
        public int UsuarioId { get; set; }
        public int CategoriaId { get; set; }
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public double Preco { get; set; }
        public bool Situacao { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
