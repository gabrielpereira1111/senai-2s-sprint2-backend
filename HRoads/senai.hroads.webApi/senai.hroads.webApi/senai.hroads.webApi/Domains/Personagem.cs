using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Personagem
    {
        public int IdPersonagens { get; set; }
        public int? IdClasses { get; set; }
        public string Nome { get; set; }
        public int QntVida { get; set; }
        public int QntMana { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataCriacao { get; set; }


        public virtual Classe IdClassesNavigation { get; set; }
    }
}
