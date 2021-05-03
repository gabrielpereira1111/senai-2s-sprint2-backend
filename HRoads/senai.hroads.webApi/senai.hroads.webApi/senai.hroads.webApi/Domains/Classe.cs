using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Classe
    {
        public Classe()
        {
            ClassesHabilidades = new HashSet<ClassesHabilidade>();
            Personagens = new HashSet<Personagem>();
        }

        public int IdClasses { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<ClassesHabilidade> ClassesHabilidades { get; set; }
        public virtual ICollection<Personagem> Personagens { get; set; }
    }
}
