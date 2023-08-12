using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BernhoeftApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {

        }

        public Usuario(int tipoUsarioId, string nome, string email, string senha)
        {
            TipoUsuarioId = tipoUsarioId;
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        [Key]
        public int UsuarioId { get; set; }
        public int TipoUsuarioId { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;

        public virtual TipoUsuario TipoUsuario { get; set;} = null!;
    }
}
