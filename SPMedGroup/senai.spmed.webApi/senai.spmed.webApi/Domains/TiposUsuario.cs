using System;
using System.Collections.Generic;

#nullable disable

namespace senai.spmed.webApi.Domains
{
    public partial class TiposUsuario
    {
        public TiposUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdtiposUsuarios { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
