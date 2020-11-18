using ApiAgendamentos.Models;
using ApiAgendamentos.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamentos.Services
{
    public class GerenciadorOcorrencia : IGerenciadorOcorrencia
    {
        private readonly bancoagendamentoContext _context;

        public GerenciadorOcorrencia(bancoagendamentoContext context)
        {
            _context = context;
        }
        public void Editar(Models.Ocorrencia ocorrenciaModel)
        {
            try
            {
                Persistence.Ocorrencia tbocorrencia = new Persistence.Ocorrencia();
                Atribuir(ocorrenciaModel, tbocorrencia);
                _context.Update(tbocorrencia);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"Ocorrencia não atualizada. Erro de {e.Message}");
            }
        }

        private void Atribuir(Models.Ocorrencia ocorrenciaModel, Persistence.Ocorrencia tbocorrencia)
        {
            try
            {
                tbocorrencia.Id = ocorrenciaModel.Id;
                tbocorrencia.Data = ocorrenciaModel.Data;
                tbocorrencia.Descricao = ocorrenciaModel.Descricao;
                tbocorrencia.IdFuncionario = ocorrenciaModel.IdFuncionario;
            }
            catch (Exception e)
            {
                throw new Exception($"Dados de ocorrencia não atribuidos. Erro {e.Message}");
            }
        }

        public void Inserir(Models.Ocorrencia ocorrenciaModel)
        {
            Persistence.Ocorrencia _tbocorrencia = new Persistence.Ocorrencia();
            _tbocorrencia.Id = ocorrenciaModel.Id;
            _tbocorrencia.Descricao = ocorrenciaModel.Descricao;
            _tbocorrencia.IdFuncionario = ocorrenciaModel.IdFuncionario;
            _tbocorrencia.Data = ocorrenciaModel.Data;
            _context.Add(_tbocorrencia);
            _context.SaveChanges();
        }

        public Models.Ocorrencia Obter(int idOcorrencia)
        {
            IEnumerable<Models.Ocorrencia> ocorrencias = GetQuery().Where(ocorrenciaModel => ocorrenciaModel.Id.Equals(idOcorrencia));
            return ocorrencias.ElementAtOrDefault(0);
        }

        private IEnumerable<Models.Ocorrencia> GetQuery()
        {
            IQueryable<Persistence.Ocorrencia> tbocorrencia = _context.Ocorrencia;
            var query = from ocorrenciaModel in tbocorrencia
                        select new Models.Ocorrencia
                        {
                            Id = ocorrenciaModel.Id,
                            Descricao = ocorrenciaModel.Descricao,
                            IdFuncionario = ocorrenciaModel.IdFuncionario,
                            Data = ocorrenciaModel.Data
        };
            return query;
        }

        public IEnumerable<Models.Ocorrencia> ObterTodos()
        {
            return GetQuery();
        }
        public bool OcorrenciaExiste(int id)
        {
            return _context.Ocorrencia.Any(item => item.Id == id);
        }

        public void Remover(int idOcorrencia)
        {
            var ocorrencia = _context.Ocorrencia.Find(idOcorrencia);
            _context.Ocorrencia.Remove(ocorrencia);
            _context.SaveChanges();
        }
    }
}
