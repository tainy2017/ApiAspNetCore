using System;
using System.Collections.Generic;

namespace ApiAgendamentos.Persistence
{
    public partial class Pessoas
    {
        public Pessoas()
        {
            AgendamentosIdClienteNavigation = new HashSet<Agendamentos>();
            AgendamentosIdFuncionarioNavigation = new HashSet<Agendamentos>();
            Horarios = new HashSet<Horarios>();
            Ocorrencias = new HashSet<Ocorrencias>();
            ServicoFuncionarios = new HashSet<ServicoFuncionarios>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Cargo { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Complemento { get; set; }
        public int? Numero { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public short IsFuncionario { get; set; }
        public int IdEstabelecimento { get; set; }

        public virtual Estabelecimentos IdEstabelecimentoNavigation { get; set; }
        public virtual ICollection<Agendamentos> AgendamentosIdClienteNavigation { get; set; }
        public virtual ICollection<Agendamentos> AgendamentosIdFuncionarioNavigation { get; set; }
        public virtual ICollection<Horarios> Horarios { get; set; }
        public virtual ICollection<Ocorrencias> Ocorrencias { get; set; }
        public virtual ICollection<ServicoFuncionarios> ServicoFuncionarios { get; set; }
    }
}
