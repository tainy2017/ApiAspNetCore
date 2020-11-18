using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamentos.Models
{
    public class Estabelecimento
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        
    }
}
