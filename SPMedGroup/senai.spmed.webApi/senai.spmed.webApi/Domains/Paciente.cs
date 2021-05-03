using System;
using System.Collections.Generic;

#nullable disable

namespace senai.spmed.webApi.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int Idpacientes { get; set; }
        public int? Idusuarios { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }

        public virtual Usuario IdusuariosNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
