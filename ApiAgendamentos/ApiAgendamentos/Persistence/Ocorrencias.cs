using System;
using System.Collections.Generic;

namespace ApiAgendamentos.Persistence
{
    public partial class Ocorrencias
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public int IdFuncionario { get; set; }

        public virtual Pessoas IdFuncionarioNavigation { get; set; }
    }
}
