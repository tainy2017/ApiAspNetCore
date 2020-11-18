using System;
using System.Collections.Generic;

namespace ApiAgendamentos.Persistence
{
    public partial class Horarios
    {
        public int Id { get; set; }
        public TimeSpan Inicio { get; set; }
        public TimeSpan Fim { get; set; }
        public byte DiaSemana { get; set; }
        public int IdEmpresa { get; set; }
        public int IdFuncionario { get; set; }

        public virtual Empresas IdEmpresaNavigation { get; set; }
        public virtual Pessoas IdFuncionarioNavigation { get; set; }
    }
}
