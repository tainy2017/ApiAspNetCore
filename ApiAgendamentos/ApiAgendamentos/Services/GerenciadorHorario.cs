using ApiAgendamentos.Models;
using ApiAgendamentos.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamentos.Services
{
    public class GerenciadorHorario : IGerenciadorHorario
    {
        private readonly bancoagendamentoContext _context;

        public GerenciadorHorario(bancoagendamentoContext context)
        {
            _context = context;
        }
        public bool HorarioExiste(int id)
        {
            return _context.Horario.Any(item => item.Id == id);
        }
        public void Editar(Models.Horario horarioModel)
        {
            try
            {
                Persistence.Horario tbhorario = new Persistence.Horario();
                Atribuir(horarioModel, tbhorario);
                _context.Update(tbhorario);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"Empresa não atualizada. Erro de {e.Message}");
            }
        }

        private void Atribuir(Models.Horario horarioModel, Persistence.Horario tbhorario)
        {
            try
            {
                tbhorario.Id = horarioModel.Id;
                tbhorario.IdEmpresa = horarioModel.IdEmpresa;
                tbhorario.IdFuncionario = horarioModel.IdFuncionario;
                tbhorario.Inicio = horarioModel.Inicio;
                tbhorario.Fim = horarioModel.Fim;
                tbhorario.DiaSemana = horarioModel.Dia_Semana;   
            }
            catch (Exception e)
            {
                throw new Exception($"Dados de horario não atribuidos. Erro {e.Message}");
            }
        }

        public void Inserir(Models.Horario horarioModel)
        {
            Persistence.Horario _tbhorario = new Persistence.Horario();
            _tbhorario.Id = horarioModel.Id;
            _tbhorario.IdEmpresa = horarioModel.IdEmpresa;
            _tbhorario.IdFuncionario = horarioModel.IdFuncionario;
            _tbhorario.Inicio = horarioModel.Inicio;
            _tbhorario.Fim = horarioModel.Fim;
            _tbhorario.DiaSemana = horarioModel.Dia_Semana;
           
            _context.Add(_tbhorario);
            _context.SaveChanges();
        }

        public Models.Horario Obter(int idHorario)
        {
            IEnumerable<Models.Horario> horarios = GetQuery().Where(HorarioModel => HorarioModel.Id.Equals(idHorario));
            return horarios.ElementAtOrDefault(0);
        }

        private IEnumerable<Models.Horario> GetQuery()
        {
            IQueryable<Persistence.Horario> tbhorario = _context.Horario;
            var query = from horarioModel in tbhorario
                        select new Models.Horario
                        {
                            Id = horarioModel.Id,
                            IdEmpresa = horarioModel.IdEmpresa,
                            IdFuncionario = horarioModel.IdFuncionario,
                            Inicio = horarioModel.Inicio,
                            Fim = horarioModel.Fim,
                            Dia_Semana = horarioModel.DiaSemana
        };
            return query;
        }

        public IEnumerable<Models.Horario> ObterTodos()
        {
            return GetQuery();
        }
        public void Remover(int idHorario)
        {
            var horario = _context.Empresa.Find(idHorario);
            _context.Empresa.Remove(horario);
            _context.SaveChanges();
        }
    }
}
