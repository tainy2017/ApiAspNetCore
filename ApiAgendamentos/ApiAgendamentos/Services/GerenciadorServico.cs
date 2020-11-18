using ApiAgendamentos.Models;
using ApiAgendamentos.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamentos.Services
{
    public class GerenciadorServico : IGerenciadorServico
    {
        private readonly bancoagendamentoContext _context;

        public GerenciadorServico(bancoagendamentoContext context)
        {
            _context = context;
        }
        public void Editar(Models.Servico servicoModel)
        {
            try
            {
                Persistence.Servico tbservico = new Persistence.Servico();
                Atribuir(servicoModel, tbservico);
                _context.Update(tbservico);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"Serviço não atualizado. Erro de {e.Message}");
            }
        }

        private void Atribuir(Models.Servico servicoModel, Persistence.Servico tbservico)
        {
            try
            {
                tbservico.Id = servicoModel.Id;
                tbservico.Nome = servicoModel.Nome;
            }
            catch (Exception e)
            {
                throw new Exception($"Dados de serviço não atribuidos. Erro {e.Message}");
            }
        }

        public void Inserir(Models.Servico servicoModel)
        {
            Persistence.Servico _tbservico = new Persistence.Servico();
            _tbservico.Id = servicoModel.Id;
            _tbservico.Nome = servicoModel.Nome;
          
            _context.Add(_tbservico);
            _context.SaveChanges();
        }

        public Models.Servico Obter(int idServico)
        {
            IEnumerable<Models.Servico> servicos = GetQuery().Where(servicoModel => servicoModel.Id.Equals(idServico));
            return servicos.ElementAtOrDefault(0);
        }

        private IEnumerable<Models.Servico> GetQuery()
        {
            IQueryable<Persistence.Servico> tbservico = _context.Servico;
            var query = from servicoModel in tbservico
                        select new Models.Servico
                        {
                            Id = servicoModel.Id,
                            Nome = servicoModel.Nome  
                        };
            return query;
        }

        public IEnumerable<Models.Servico> ObterPorNome(string nome)
        {
            IEnumerable<Models.Servico> servicos = GetQuery().Where(servicoModel => servicoModel.Nome.StartsWith(nome));
            return servicos;
        }

        public IEnumerable<Models.Servico> ObterTodos()
        {
            return GetQuery();
        }
        public bool ServicoExiste(int id)
        {
            return _context.Empresa.Any(item => item.Id == id);
        }
        public void Remover(int idServico)
        {
            var servico = _context.Servico.Find(idServico);
            _context.Servico.Remove(servico);
            _context.SaveChanges();
        }
    }
}
