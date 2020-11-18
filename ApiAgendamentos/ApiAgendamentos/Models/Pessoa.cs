using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamentos.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Cargo { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Complemento { get; set; }
        public int Numero { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public int Id_Funcionario { get; set; }
        public int Id_Estabelecimento { get; set; }
        public Servico Servico { get; set; }
        public virtual ICollection<EstabelecimentosPessoas> EstabelecimentosPessoas { get; set; }
        public virtual ICollection<HorarioPessoas> HorarioPessoas { get; set; }
        public virtual ICollection<Ocorrencia> Ocorrencias { get; set; }
    }
}
