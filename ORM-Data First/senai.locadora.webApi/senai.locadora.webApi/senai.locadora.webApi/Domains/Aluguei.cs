using System;
using System.Collections.Generic;

#nullable disable

namespace senai.locadora.webApi.Domains
{
    public partial class Aluguei
    {
        public Aluguei()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int IdAlugueis { get; set; }
        public int? IdVeiculos { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime DataEntrega { get; set; }
        public decimal ValorAluguel { get; set; }
        public int? IdClientes { get; set; }

        public virtual Cliente IdClientesNavigation { get; set; }
        public virtual Veiculo IdVeiculosNavigation { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
