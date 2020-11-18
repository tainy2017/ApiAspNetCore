using System;
using System.Collections.Generic;

namespace ApiAgendamentos.Persistence
{
    public partial class Estabelecimentos
    {
        public Estabelecimentos()
        {
            Pessoas = new HashSet<Pessoas>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Pessoas> Pessoas { get; set; }
    }
}
