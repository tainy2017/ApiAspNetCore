using System;
using System.Collections.Generic;

namespace ApiAgendamentos.Persistence
{
    public partial class Servicos
    {
        public Servicos()
        {
            ServicoFuncionarios = new HashSet<ServicoFuncionarios>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<ServicoFuncionarios> ServicoFuncionarios { get; set; }
    }
}
