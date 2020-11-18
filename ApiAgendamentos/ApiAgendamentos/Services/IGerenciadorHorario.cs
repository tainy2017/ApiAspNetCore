using ApiAgendamentos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamentos.Services
{
    public interface IGerenciadorHorario
    {
        void Editar(Horario horarioModel);
        void Inserir(Horario horarioModel);
        Horario Obter(int idHorario);
        IEnumerable<Horario> ObterTodos();
        void Remover(int idHorario);
        bool HorarioExiste(int id);
    }
}
