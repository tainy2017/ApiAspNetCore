using System;
using System.Collections.Generic;

namespace ApiAgendamentos.Persistence
{
    public partial class Agendamento
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public string Status { get; set; }
        public int IdCliente { get; set; }
        public int IdFuncionario { get; set; }
        public int IdEmpresa { get; set; }
    }
}
