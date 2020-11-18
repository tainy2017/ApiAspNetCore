using System;
using System.Collections.Generic;

namespace ApiAgendamentos.Persistence
{
    public partial class Agendamentos
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public string Status { get; set; }
        public string MeioComunicacao { get; set; }
        public int IdCliente { get; set; }
        public int IdFuncionario { get; set; }
        public int IdEmpresa { get; set; }

        public virtual Pessoas IdClienteNavigation { get; set; }
        public virtual Empresas IdEmpresaNavigation { get; set; }
        public virtual Pessoas IdFuncionarioNavigation { get; set; }
    }
}
