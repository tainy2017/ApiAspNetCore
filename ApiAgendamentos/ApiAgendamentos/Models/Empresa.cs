using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamentos.Models
{
    public class Empresa
    {
        public Empresa()
        {
            HorarioEmpresas = new HashSet<HorarioEmpresas>();
            Agendamentos = new HashSet<Agendamento>();
        }
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Cnpj { get; set; }
        //1 empresa pode ter vários horários
        public virtual ICollection<HorarioEmpresas> HorarioEmpresas { get; set; }
        //1 empresa pode ter vários agendamentos
        public virtual ICollection<Agendamento> Agendamentos { get; set; }
    }
}
