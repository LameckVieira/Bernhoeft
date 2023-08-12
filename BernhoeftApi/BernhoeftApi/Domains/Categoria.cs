using System;
using System.Collections.Generic;

namespace BernhoeftApi.Domains
{
    public partial class Categoria
    {
        public int IdCategoria { get; set; }
        public int IdUsuario { get; set; }
        public string Nome { get; set; } = null!;
        public bool Situacao { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
