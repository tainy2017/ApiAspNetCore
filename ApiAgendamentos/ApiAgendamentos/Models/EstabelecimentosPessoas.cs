using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamentos.Models
{
    public class EstabelecimentosPessoas
    {
      //  [Key]
        public int IdEstabelecimento { get; set; }
        public int IdPessoa { get; set; }
        public string nome { get; set; }

        public virtual Estabelecimento Estabelecimento { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
