using System;
using System.Collections.Generic;

namespace ApiAgendamentos.Persistence
{
    public partial class Empresas
    {
        public Empresas()
        {
            Agendamentos = new HashSet<Agendamentos>();
            Horarios = new HashSet<Horarios>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }

        public virtual ICollection<Agendamentos> Agendamentos { get; set; }
        public virtual ICollection<Horarios> Horarios { get; set; }
    }
}
