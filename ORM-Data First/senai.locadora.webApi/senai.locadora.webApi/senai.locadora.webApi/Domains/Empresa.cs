using System;
using System.Collections.Generic;

#nullable disable

namespace senai.locadora.webApi.Domains
{
    public partial class Empresa
    {
        public Empresa()
        {
            Veiculos = new HashSet<Veiculo>();
        }

        public int IdEmpresa { get; set; }
        public string Endereco { get; set; }
        public string Cnpj { get; set; }

        public virtual ICollection<Veiculo> Veiculos { get; set; }
    }
}
