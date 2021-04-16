using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_WebApi.Domain
{
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }
        [Required(ErrorMessage = "Email obrigatório!")]
        public string email { get; set; }
        [Required(ErrorMessage = "Senha obrigatória")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "A senha precisa ser no mínimo 3 e no máximo 20 caracteres")]
        public string senha { get; set; }
        
        public string tipoUsuario { get; set; }
    }
}
