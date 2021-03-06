using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class ClassesHabilidade
    {
        public int IdClassesHabilidades { get; set; }
        public int? IdClasses { get; set; }
        public int? IdHabilidades { get; set; }

        public virtual Classe IdClassesNavigation { get; set; }
        public virtual Habilidade IdHabilidadesNavigation { get; set; }
    }
}
