﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamentos.Models
{
    public class Servico
    {
        public Servico()
        {
            ServicosFuncionarios = new HashSet<ServicosFuncionarios>();

        }
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<ServicosFuncionarios> ServicosFuncionarios { get; set; }

    }
}
