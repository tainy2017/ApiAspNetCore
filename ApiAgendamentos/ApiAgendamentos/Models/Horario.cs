using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamentos.Models
{
    public class Horario
    {
        public Horario()
        {
            HorarioEmpresas = new HashSet<HorarioEmpresas>();
            HorarioPessoas = new HashSet<HorarioPessoas>();
        }
        [Key]
        public int Id { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public string Dia_Semana { get; set; }
        public int IdEmpresa { get; set; }
        public int IdFuncionario { get; set; }
        public virtual ICollection<HorarioEmpresas> HorarioEmpresas { get; set; }
        public virtual ICollection<HorarioPessoas> HorarioPessoas { get; set; }
       
    }
}
