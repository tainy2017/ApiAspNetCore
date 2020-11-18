using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiAgendamentos.Models
{
    public class Agendamento
    {
        //1 agendamento tem uma empresa, 1 pessoa tipo cliente
        [Key]
        [Required]
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public DateTime Hora { get; set; }
        public string Status { get; set; }

        public int Id_Cliente { get; set; }

        public int Id_Funcionario { get; set; }
        public int Id_Empresa { get; set; }

    }
}
