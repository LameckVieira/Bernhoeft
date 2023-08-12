using System;
using System.Collections.Generic;

namespace BernhoeftApi.Domains
{
    public partial class Produto
    {
        public Produto()
        {
            Categoria = new HashSet<Categoria>();
        }

        public int IdProduto { get; set; }
        public int IdUsuario { get; set; }
        public int IdCategoria { get; set; }
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public double Preco { get; set; }
        public bool Situacao { get; set; }

        public virtual ICollection<Categoria> Categoria { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual Categoria IdCategoriaNavigation { get; set; }

    }
}
