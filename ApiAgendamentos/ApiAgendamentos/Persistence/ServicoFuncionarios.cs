using System;
using System.Collections.Generic;

namespace ApiAgendamentos.Persistence
{
    public partial class ServicoFuncionarios
    {
        public int IdServico { get; set; }
        public int IdFuncionario { get; set; }

        public virtual Pessoas IdFuncionarioNavigation { get; set; }
        public virtual Servicos IdServicoNavigation { get; set; }
    }
}
