using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Habilidade
    {
        public Habilidade()
        {
            ClassesHabilidades = new HashSet<ClassesHabilidade>();
        }

        public int IdHabilidades { get; set; }
        public int? IdTipo { get; set; }
        public string Nome { get; set; }

        public virtual TiposHabilidade IdTipoNavigation { get; set; }
        public virtual ICollection<ClassesHabilidade> ClassesHabilidades { get; set; }
    }
}
