using System;
using System.Collections.Generic;

namespace ApiAgendamentos.Persistence
{
    public partial class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Cargo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Complemento { get; set; }
        public int Numero { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public int IdFuncionario { get; set; }
        public int IdEstabelecimento { get; set; }
    }
}
