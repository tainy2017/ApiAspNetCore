using System;
using System.Collections.Generic;

namespace ApiAgendamentos.Persistence
{
    public partial class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
    }
}
