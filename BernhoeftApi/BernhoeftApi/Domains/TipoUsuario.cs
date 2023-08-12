using System;
using System.Collections.Generic;

namespace BernhoeftApi.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }
        public string TipoUsusario { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
