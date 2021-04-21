using System;
using System.Collections.Generic;

#nullable disable

namespace senai.locadora.webApi.Domains
{
    public partial class Veiculo
    {
        public Veiculo()
        {
            Alugueis = new HashSet<Aluguei>();
        }

        public int IdVeiculos { get; set; }
        public int? IdEmpresa { get; set; }
        public string Placas { get; set; }
        public string Modelos { get; set; }
        public string Marcas { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual ICollection<Aluguei> Alugueis { get; set; }
    }
}
