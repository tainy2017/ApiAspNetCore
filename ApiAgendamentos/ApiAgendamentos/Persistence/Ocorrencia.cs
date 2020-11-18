using System;
using System.Collections.Generic;

namespace ApiAgendamentos.Persistence
{
    public partial class Ocorrencia
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public int IdFuncionario { get; set; }
    }
}
