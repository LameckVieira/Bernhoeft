using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BernhoeftApi.Domains
{
    public partial class Categoria
    {
        public Categoria()
        {
                
        }

        public Categoria(int usuarioid, string nome, bool situacao)
        {
            UsuarioId = usuarioid;
            Nome = nome;
            Situacao = situacao;
        }

        [Key]
        public int CategoriaId { get; set; }
        public int UsuarioId { get; set; }
        public string Nome { get; set; } = null!;
        public bool Situacao { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
