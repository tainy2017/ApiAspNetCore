using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamentos.Models
{
    public class ServicosFuncionarios
    {
        [Key]
        public int IdServico { get; set; }
        public int IdPessoaIdFuncionario { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
