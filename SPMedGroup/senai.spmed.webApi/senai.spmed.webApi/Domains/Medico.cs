using System;
using System.Collections.Generic;

#nullable disable

namespace senai.spmed.webApi.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int Idmedicos { get; set; }
        public int? Idespecialidades { get; set; }
        public int? Idclinicas { get; set; }
        public int? Idusuarios { get; set; }
        public string Nome { get; set; }
        public string Crm { get; set; }

        public virtual Clinica IdclinicasNavigation { get; set; }
        public virtual Especialidade IdespecialidadesNavigation { get; set; }
        public virtual Usuario IdusuariosNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
