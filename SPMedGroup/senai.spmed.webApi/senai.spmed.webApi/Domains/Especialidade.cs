using System;
using System.Collections.Generic;

#nullable disable

namespace senai.spmed.webApi.Domains
{
    public partial class Especialidade
    {
        public Especialidade()
        {
            Medicos = new HashSet<Medico>();
        }

        public int Idespecialidades { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
