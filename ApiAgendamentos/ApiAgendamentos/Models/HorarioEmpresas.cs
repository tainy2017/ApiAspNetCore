using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamentos.Models
{
    public class HorarioEmpresas
    {
        [Key]
        public int IdHorario { get; set; }
        public int IdEmpresa { get; set; }

        public virtual Horario IdHorarioNavigation { get; set; }
        public virtual Empresa IdEmpresaNavigation { get; set; }
    }
}
