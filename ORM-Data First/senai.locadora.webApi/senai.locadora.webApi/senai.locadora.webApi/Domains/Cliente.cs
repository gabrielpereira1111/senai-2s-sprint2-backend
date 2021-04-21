using System;
using System.Collections.Generic;

#nullable disable

namespace senai.locadora.webApi.Domains
{
    public partial class Cliente
    {
        public Cliente()
        {
            Alugueis = new HashSet<Aluguei>();
        }

        public int IdCliente { get; set; }
        public int? IdAlugueis { get; set; }
        public string Nome { get; set; }
        public string Telefones { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }

        public virtual Aluguei IdAlugueisNavigation { get; set; }
        public virtual ICollection<Aluguei> Alugueis { get; set; }
    }
}
