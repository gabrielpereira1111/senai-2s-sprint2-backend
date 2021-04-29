using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Class
    {
        public Class()
        {
            ClassesHabilidades = new HashSet<ClassesHabilidade>();
            Personagens = new HashSet<Personagen>();
        }

        public int IdClasses { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<ClassesHabilidade> ClassesHabilidades { get; set; }
        public virtual ICollection<Personagen> Personagens { get; set; }
    }
}
