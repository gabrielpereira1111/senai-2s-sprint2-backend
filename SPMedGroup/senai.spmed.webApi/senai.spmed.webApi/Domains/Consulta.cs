using System;
using System.Collections.Generic;

#nullable disable

namespace senai.spmed.webApi.Domains
{
    public partial class Consulta
    {
        public int Idconsultas { get; set; }
        public int? Idmedicos { get; set; }
        public int? Idpacientes { get; set; }
        public DateTime DataConsulta { get; set; }
        public string Situacao { get; set; }
        public string descricao { get; set; }

        public virtual Medico IdmedicosNavigation { get; set; }
        public virtual Paciente IdpacientesNavigation { get; set; }
    }
}
