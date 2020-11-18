using System;
using System.Collections.Generic;

namespace ApiAgendamentos.Persistence
{
    public partial class Horario
    {
        public int Id { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public string DiaSemana { get; set; }
        public int IdEmpresa { get; set; }
        public int IdFuncionario { get; set; }
    }
}
