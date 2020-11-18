using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamentos.Models
{
    public class HorarioPessoas
    {
        [Key]
        public int IdHorario { get; set; }
        public int IdPessoa { get; set; }

        public virtual Horario IdHorarioNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
