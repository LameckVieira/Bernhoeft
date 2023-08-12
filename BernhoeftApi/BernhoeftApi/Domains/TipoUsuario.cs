using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BernhoeftApi.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {

        }

        public TipoUsuario(string tipoUsuario)
        {
            TipoUsusario = tipoUsuario;
        }

        [Key]
        public int TipoUsuarioId { get; set; }
        public string TipoUsusario { get; set; } = null!;

    }
}
