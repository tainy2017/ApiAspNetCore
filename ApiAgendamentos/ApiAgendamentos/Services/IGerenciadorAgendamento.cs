using System.Collections.Generic;
using ApiAgendamentos.Models;


namespace ApiAgendamentos.Services
{
    public interface IGerenciadorAgendamento
    {
        void Editar(Agendamento agendamentoModel);
        bool AgendamentoExiste(int idAgendamento);
        void Inserir(Agendamento agendamentoModel);
        Agendamento Obter(int idAgendamento);
        IEnumerable<Agendamento> ObterTodos();
        void Remover(int idAgendamento);
    }
}
