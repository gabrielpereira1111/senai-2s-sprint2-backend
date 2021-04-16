using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Domains
{
    public class FuncionariosDomain
    {
        public int     idFuncionarios  { get; set; }     
        [Required(ErrorMessage ="O nome é obrigatório!")]
        public string  Nome            { get; set; }
        public string  Sobrenome       { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}
