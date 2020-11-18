using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiAgendamentos.Models
{
    public class Ocorrencia
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public int IdFuncionario { get; set; }

    }
}
