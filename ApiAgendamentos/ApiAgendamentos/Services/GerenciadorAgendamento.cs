using System;
using System.Collections.Generic;
using ApiAgendamentos.Persistence;
using System.Linq;

namespace ApiAgendamentos.Services
{
    public class GerenciadorAgendamento : IGerenciadorAgendamento
    {
        private readonly bancoagendamentoContext _context;

        public GerenciadorAgendamento(bancoagendamentoContext context)
        {
            _context = context;
        }
        public void Editar(Models.Agendamento agendamentoModel)
        {
            try
            {
                Persistence.Agendamento tbagendamento = new Persistence.Agendamento();
                Atribuir(agendamentoModel, tbagendamento);
                _context.Update(tbagendamento);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"Agendamento não atualizado. Erro de {e.Message}");
            }
        }

        private void Atribuir(Models.Agendamento agendamentoModel, Persistence.Agendamento tbagendamento)
        {
            try
            {
                tbagendamento.Id = agendamentoModel.Id;
                tbagendamento.IdCliente = agendamentoModel.Id_Cliente;
                tbagendamento.IdEmpresa = agendamentoModel.Id_Empresa;
                tbagendamento.IdFuncionario = agendamentoModel.Id_Funcionario;
                tbagendamento.Status = agendamentoModel.Status;
                tbagendamento.Hora = agendamentoModel.Hora;
                tbagendamento.Data = agendamentoModel.Data;
            }
            catch (Exception e)
            {
                throw new Exception($"Dados não atribuidos. Erro {e.Message}");
            }
        }

        public void Inserir(Models.Agendamento agendamentoModel)
        {
            Persistence.Agendamento _tbAgendamento = new Persistence.Agendamento();
            _tbAgendamento.Id = agendamentoModel.Id;
            _tbAgendamento.Hora = agendamentoModel.Hora;
            _tbAgendamento.IdCliente = agendamentoModel.Id_Cliente ;
            _tbAgendamento.IdEmpresa = agendamentoModel.Id_Empresa;
            _tbAgendamento.IdFuncionario = agendamentoModel.Id_Funcionario;
            _tbAgendamento.Data = agendamentoModel.Data;
            _tbAgendamento.Status = agendamentoModel.Status;

            _context.Add(_tbAgendamento);
            _context.SaveChanges();
        }

        public Models.Agendamento Obter(int idAgendamento)
        {
            IEnumerable<Models.Agendamento> agendamentos = GetQuery().Where(agendamentoModel => agendamentoModel.Id.Equals(idAgendamento));
            return agendamentos.ElementAtOrDefault(0);
        }

        private IQueryable<Models.Agendamento> GetQuery()
        {
            IQueryable<Persistence.Agendamento> tbAgendamento = _context.Agendamento;
            var query = from agendamentoModel in tbAgendamento
                        select new Models.Agendamento
                        {

                            Id = agendamentoModel.Id,
                            Hora = agendamentoModel.Hora,
                            Id_Cliente = agendamentoModel.IdCliente,
                            Id_Empresa = agendamentoModel.IdEmpresa,
                            Id_Funcionario = agendamentoModel.IdFuncionario,
                            Status = agendamentoModel.Status,
                            Data = agendamentoModel.Data
                        };
            return query;
        }

        public IEnumerable<Models.Agendamento> ObterTodos()
        {
            return GetQuery();
        }
        public bool AgendamentoExiste(int idAgendamento)
        {
            return _context.Agendamento.Any(item => item.Id == idAgendamento);
        }
        public void Remover(int idAgendamento)
        {
            var agendamento = _context.Agendamento.Find(idAgendamento);
            _context.Agendamento.Remove(agendamento);
            _context.SaveChanges();
        }
    }
}
