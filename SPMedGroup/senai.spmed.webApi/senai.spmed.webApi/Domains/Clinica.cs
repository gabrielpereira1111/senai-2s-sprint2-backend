using System;
using System.Collections.Generic;

#nullable disable

namespace senai.spmed.webApi.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        public int Idclinicas { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Endereco { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
